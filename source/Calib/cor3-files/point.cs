#region User/License
// Copyright (c) 2005-2013 tfwroble
// 
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
#endregion
/* oOo * 11/28/2007 : 5:29 PM */

using System;
using System.Diagnostics;
#if WFORMS
using System.Windows.Forms;
#endif
using System.Xml.Serialization;

namespace System.Drawing
{

#if !WFORMS
  public class Padding
  {
    public int Top, Right, Bottom, Left;

  }
#endif

  [Flags] public enum scaleFlags { autoScale = 0, sWidth = 1, sHeight = 2 }
  
  /// <remarks>
  /// Only Add and Neg calls have Integer parameters when compared to the
  /// other parameter based calls (because they were most recently added).
  /// 
  /// and where is the lerp?
  /// </remarks>
  public class FloatPoint : IComparable
  {
    /// Returnes a Floored point (copy)
    static public FloatPoint Floor(FloatPoint source)
    {
      return new FloatPoint(Math.Floor(source.X),Math.Floor(source.Y));
    }
    /// nearest int: digits
    static public FloatPoint Round(FloatPoint source, int digits)
    {
      return new FloatPoint(Math.Round(source.X,digits),Math.Round(source.Y,digits));
    }
    /// nearest int
    static public FloatPoint Round(FloatPoint source)
    {
      return Round(source,0);
    }
    public FloatPoint Floored { get { return Floor(this); } }
    public FloatPoint Rounded { get { return Round(this,0); } }
    
    static readonly FloatPoint emptyPoint = new FloatPoint(0f);
    static public FloatPoint Empty { get { return emptyPoint; } }
    static public FloatPoint One { get { return new FloatPoint(1f); } }
    
    float _X, _Y;
    [XmlAttribute] public float X { get { return _X; } set { _X = value; } }
    [XmlAttribute] public float Y { get { return _Y; } set { _Y = value; } }
    
    #region Properties
    [XmlIgnore] public float Bigger { get { return (X >= Y)? X: Y; } }
    [XmlIgnore] public bool IsLand { get { return X >= Y; } }
    /// <summary>zerod'</summary>
    [XmlIgnore] public double Slope { get  { return Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)); }  }
    #endregion
    #region Static Methods
    static public FloatPoint Average(params FloatPoint[] xp)
    {
      FloatPoint p = new FloatPoint(0);
      foreach (FloatPoint pt in xp) p += pt;
      return p/xp.Length;
    }
    static public FloatPoint FlattenPoint(FloatPoint _pin, bool roundUp)
    {
      FloatPoint newP = _pin.Clone();
      if (newP.X==newP.Y) return newP;
      if (_pin.X > _pin.Y) { if (roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
      else { if (!roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
      return newP;
    }
    static public FloatPoint FlattenPoint(FloatPoint _pin) { return FlattenPoint(_pin,false); }
    /// <summary>same as FlattenPoint overload without boolean</summary>
    static public FloatPoint FlattenDown(FloatPoint _pin) { return FlattenPoint(_pin); }
    static public FloatPoint FlattenUp(FloatPoint _pin) { return FlattenPoint(_pin,true); }
#if WFORMS
    static public FloatPoint GetClientSize(Control ctl) { return ctl.ClientSize; }
#endif
    static public FloatPoint GetPaddingTopLeft(Padding pad) { return new FloatPoint(pad.Left,pad.Top); }
    static public FloatPoint GetPaddingOffset(Padding pad) { return new FloatPoint(pad.Left+pad.Right,pad.Top+pad.Bottom); }
    //
    static public FloatPoint Angus(float offset, float ration, float phase) { return new FloatPoint(-Math.Sin(cvtf(ration,offset+phase)),Math.Cos(cvtf(ration,offset+phase))); }
    static public FloatPoint Angus(float offset, float ration) { return Angus(offset,ration,0.0f); }
    static float cvtf(float S, float I){ return (float)((Math.PI*2)*(I/S)); }
    /// scales src to dest
    static public FloatPoint Fit(FloatPoint dest, FloatPoint source)
    {
      return Fit(dest, source, 0);
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="dest"></param>
    /// <param name="source"></param>
    /// <param name="ScaleFlagBit"> 0x00 | (width) 0x01 | (height) 0x02 = 0x03 so you can check both width and height bits with a value of three.</param>
    /// <returns></returns>
    static public FloatPoint Fit(FloatPoint dest, FloatPoint source, int ScaleFlagBit)
    {
      FloatPoint HX = dest/source;
      if (ScaleFlagBit == 0) return Fit( dest , source , 1 );
      else return (ScaleFlagBit == 1) ? source * HX.X : source * HX.Y;
    }
#region Obsolete
    /*    /// todo: replace this with something more accurate and faster
    /// use Boxed as the default scale flag
    static public HPoint Fit(Point dest, Point source, scaleFlags sf)
    {
      HPoint skaler = new HPoint();
      float tr=0;
      string omax,cmax;
      if (source.X >= source.Y) omax = "width"; else omax="height";
      if (dest.X >= dest.Y) cmax = "width"; else cmax="height";
      switch (cmax)
      {
        case "width": if (omax==cmax) sf = scaleFlags.sWidth; else sf = scaleFlags.sHeight; break;
        case "height": if (omax==cmax) sf = scaleFlags.sHeight; else sf = scaleFlags.sWidth; break;
      }
    skale:
      switch (sf)
      {
        case scaleFlags.sHeight:
          if ( source.Y > dest.Y ) { skaler.Y = dest.Y; tr = (float)((float)dest.Y / (float)source.Y); skaler.X = (int)Math.Round(source.X*tr); }
          else skaler = source; break;
        case scaleFlags.sWidth:
          if ( source.X > dest.X ) { skaler.X = dest.X; tr = (float)((float)dest.X / (float)source.X); skaler.Y = (int)Math.Round(source.Y*tr); }
          else skaler = source; break;
      }
      if ((skaler.X > dest.X) | (skaler.Y > dest.Y))
      {
        switch (sf)
        {
          case scaleFlags.sWidth: sf = scaleFlags.sHeight; goto skale;
          case scaleFlags.sHeight: sf = scaleFlags.sWidth; goto skale;
        }
      }
      return skaler;
    }*/
#endregion
#endregion
#region Help
    //    public XPoint Translate(XPoint offset, XPoint zoom, bool ZoomAfterOffset, bool MultiplyOffset)
    //    {
    //      return (ZoomAfterOffset) ? (this+((MultiplyOffset) ? offset*zoom : offset ))*zoom : (this*zoom)+((MultiplyOffset) ? offset*zoom : offset );
    //    }
    /// In most scenarios (reminding my self of my application...)
    /// zoom is applied by the renderer, so we shouldn't need it?
    /// I could be wrong.  We could be zoomed in to draw.
    public FloatPoint Translate(FloatPoint offset, FloatPoint zoom)
    {
      return (this+offset)*zoom;
    }
    public FloatPoint Translate(double offset, double zoom)
    {
      return (this+new FloatPoint(offset))*new FloatPoint(zoom);
    }
#endregion
#region Helpers “Most of which are obsoltet”
    public FloatPoint GetRation(FloatPoint dst)
    {
      return dst/this;
    }
    public FloatPoint GetScaledRation(FloatPoint dst)
    {
      return this*(dst/this);
    }
    public float Dimension() { return X*Y; }
    /// <summary>Returns a new flattened point</summary>
    public FloatPoint Flat(bool roundUp) { return FlattenPoint(this,roundUp); }
    /// <summary>Flattens the calling point</summary>
    public void Flatten(bool roundUp) { FloatPoint f = Flat(roundUp); this.X = f.X; this.Y = f.Y; f = null; }
    /// <summary>use Flat or flatten calls.</summary>
    public FloatPoint ScaleTo(FloatPoint point)
    {
      if (point.X==X && point.Y==Y) throw new InvalidOperationException("you mucker");
      //System.Windows.Forms.MessageBox.Show( string.Format("X: {1},Y: {0}",Y/point.Y,X/point.X) );
      if (X > point.Y)
      {
#if CONSOLE && COR3
        Global.cstat(ConsoleColor.Red,"X is BIGGER");
#else
        Debug.Print("X is BIGGER");
#endif
      }
#if CONSOLE && COR3
      else Global.cstat(ConsoleColor.Red,"X is SMALLER");
#else
      else Debug.Print("X is SMALLER");
#endif
      return this;
    }
#endregion
#region Operators
    
    static public FloatPoint operator +(FloatPoint a, FloatPoint b){ return new FloatPoint(a.X+b.X,a.Y+b.Y); }
    static public FloatPoint operator +(FloatPoint a, Point b){ return new FloatPoint(a.X+b.X,a.Y+b.Y); }
    static public FloatPoint operator +(FloatPoint a, int b){ return new FloatPoint(a.X+b,a.Y+b); }
    static public FloatPoint operator +(FloatPoint a, float b){ return new FloatPoint(a.X+b,a.Y+b); }
    static public FloatPoint operator +(FloatPoint a, double b){ return new FloatPoint(a.X+b,a.Y+b); }
    static public FloatPoint operator -(FloatPoint a){ return new FloatPoint(-a.X,-a.Y); }
    static public FloatPoint operator -(FloatPoint a, FloatPoint b){ return new FloatPoint(a.X-b.X,a.Y-b.Y); }
    static public FloatPoint operator -(FloatPoint a, Point b){ return new FloatPoint(a.X-b.X,a.Y-b.Y); }
    static public FloatPoint operator -(FloatPoint a, int b){ return new FloatPoint(a.X-b,a.Y-b); }
    static public FloatPoint operator -(FloatPoint a, float b){ return new FloatPoint(a.X-b,a.Y-b); }
    static public FloatPoint operator -(FloatPoint a, double b){ return new FloatPoint(a.X-b,a.Y-b); }
    static public FloatPoint operator /(FloatPoint a, FloatPoint b){ return new FloatPoint(a.X/b.X,a.Y/b.Y); }
    static public FloatPoint operator /(FloatPoint a, Point b){ return new FloatPoint(a.X/b.X,a.Y/b.Y); }
    static public FloatPoint operator /(FloatPoint a, int b){ return new FloatPoint(a.X/b,a.Y/b); }
    static public FloatPoint operator /(FloatPoint a, float b){ return new FloatPoint(a.X/b,a.Y/b); }
    static public FloatPoint operator /(FloatPoint a, double b){ return new FloatPoint(a.X/b,a.Y/b); }
    static public FloatPoint operator *(FloatPoint a, FloatPoint b){ return new FloatPoint(a.X*b.X,a.Y*b.Y); }
    static public FloatPoint operator *(FloatPoint a, Point b){ return new FloatPoint(a.X*b.X,a.Y*b.Y); }
    static public FloatPoint operator *(FloatPoint a, int b){ return new FloatPoint(a.X*b,a.Y*b); }
    static public FloatPoint operator *(FloatPoint a, float b){ return new FloatPoint(a.X*b,a.Y*b); }
    static public FloatPoint operator *(FloatPoint a, double b){ return new FloatPoint(a.X*(float)b,a.Y*(float)b); }
    static public FloatPoint operator %(FloatPoint a, FloatPoint b){ return new FloatPoint(a.X%b.X,a.Y%b.Y); }
    static public FloatPoint operator %(FloatPoint a, Point b){ return new FloatPoint(a.X%b.X,a.Y%b.Y); }
    
    static public FloatPoint operator ++(FloatPoint a){ return new FloatPoint(a.X++,a.Y++); }
    static public FloatPoint operator --(FloatPoint a){ return new FloatPoint(a.X--,a.Y--); }
    
    static public bool operator >(FloatPoint a,FloatPoint b){ return ((a.X>b.X) & (a.Y>b.Y)); }
    static public bool operator >=(FloatPoint a,FloatPoint b){ return ((a.X>=b.X) & (a.Y>=b.Y)); }
    static public bool operator <(FloatPoint a,FloatPoint b){ return ((a.X<b.X) & (a.Y<b.Y)); }
    static public bool operator <=(FloatPoint a,FloatPoint b){ return ((a.X<=b.X) & (a.Y<=b.Y)); }
    
#endregion
#region Operators Implicit
    static public implicit operator Point(FloatPoint a){ return new Point((int)a.X,(int)a.Y); }
    static public implicit operator PointF(FloatPoint a){ return new PointF(a.X,a.Y); }
    static public implicit operator Size(FloatPoint a){ return new Size((int)a.X,(int)a.Y); }
    static public implicit operator SizeF(FloatPoint a){ return new SizeF(a.X,a.Y); }
    static public implicit operator FloatPoint(Size s){ return new FloatPoint(s); }
    static public implicit operator FloatPoint(SizeF s){ return new FloatPoint(s); }
    static public implicit operator FloatPoint(Point s){ return new FloatPoint(s); }
    static public implicit operator FloatPoint(PointF s){ return new FloatPoint(s); }
    static public implicit operator FloatPoint(DPoint s){ return new FloatPoint(s); }
#endregion
#region Maths
    public bool IsXG(FloatPoint P) { return X>P.X; }
    public bool IsYG(FloatPoint P) { return Y>P.Y; }
    public bool IsXL(FloatPoint P) { return X<P.X; }
    public bool IsYL(FloatPoint P) { return Y<P.Y; }
    
    public bool IsLEq(FloatPoint p) { return (X<=p.X) && (Y<=p.Y); }
    public bool IsGEq(FloatPoint p) { return (X>=p.X) && (Y>=p.Y); }
    
    public bool IsXGEq(FloatPoint P) { return IsXG(P)&IsXG(P); }
    public bool IsYGEq(FloatPoint P) { return IsYG(P)&IsYG(P); }
    public bool IsXLEq(FloatPoint P) { return IsXG(P)&IsXG(P); }
    public bool IsYLEq(FloatPoint P) { return IsYG(P)&IsYG(P); }
    public bool IsXEq(FloatPoint P) { return X==P.X; }
    public bool IsYEq(FloatPoint P) { return Y==P.Y; }
    
    public FloatPoint Multiply(params FloatPoint[] P) {
      if (P.Length==0) throw new ArgumentException("there is no data!");
      if (P.Length==1) return new FloatPoint(X,Y)*P[0];
      FloatPoint NewPoint = new FloatPoint(X,Y)*P[0];
      for (int i = 1; i < P.Length; i++)
      {
        NewPoint *= P[i];
      }
      return NewPoint;
    }
    public FloatPoint Multiply(params float[] P) {
      if (P.Length==0) throw new ArgumentException("there is no data!");
      if (P.Length==1) return new FloatPoint(X,Y)*P[0];
      FloatPoint NewPoint = new FloatPoint(X,Y)*P[0];
      for (int i = 1; i < P.Length; i++)
      {
        NewPoint *= P[i];
      }
      return NewPoint;
    }
    public FloatPoint Divide(params FloatPoint[] P)
    {
      if (P.Length==0) throw new ArgumentException("there is no data!");
      if (P.Length==1) return new FloatPoint(X,Y)/P[0];
      FloatPoint NewPoint = new FloatPoint(X,Y)/P[0];
      for (int i = 1; i < P.Length; i++)
      {
        NewPoint /= P[i];
      }
      return NewPoint;
    }
    
    public FloatPoint MulX(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.X *= RefPoint.X;
      return PBase;
    }
    public FloatPoint MulY(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.Y *= RefPoint.Y;
      return PBase;
    }
    public FloatPoint DivX(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.X /= RefPoint.X;
      return PBase;
    }
    public FloatPoint DivY(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.Y /= RefPoint.Y;
      return PBase;
    }
    public FloatPoint AddX(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.X += RefPoint.X;
      return PBase;
    }
    public FloatPoint AddY(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.Y += RefPoint.Y;
      return PBase;
    }
    public FloatPoint AddY(params int[] P)
    {
      FloatPoint PBase = Clone();
      foreach (int RefPoint in P) PBase.Y += RefPoint;
      return PBase;
    }
    public FloatPoint NegX(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.X -= RefPoint.X;
      return PBase;
    }
    public FloatPoint NegX(params int[] P)
    {
      FloatPoint PBase = Clone();
      foreach (int Ref in P) PBase.X -= Ref;
      return PBase;
    }
    public FloatPoint NegY(params FloatPoint[] P)
    {
      FloatPoint PBase = Clone();
      foreach (FloatPoint RefPoint in P) PBase.Y -= RefPoint.Y;
      return PBase;
    }
    public FloatPoint NegY(params int[] P)
    {
      FloatPoint PBase = Clone();
      foreach (int Ref in P) PBase.Y -= Ref;
      return PBase;
    }
#endregion
    
//    public FloatPoint() : this(0,0){  }
    public FloatPoint(FloatPoint y){ this._X = y.X; this._Y = y.Y; }
    public FloatPoint(float x, float y){ _X = x; _Y = y; }
    public FloatPoint(int value) : this(value,value) {  }
    public FloatPoint(float value) : this(value,value) {  }
    public FloatPoint(double value) : this(value,value) {  }
    public FloatPoint(double x, double y) : this((float)x,(float)y) {  }
    public FloatPoint(DPoint P) : this(P.X,P.Y) {}
    public FloatPoint(Point P){ _X = P.X; _Y = P.Y; }
    public FloatPoint(PointF P){ _X = P.X; _Y = P.Y; }
    public FloatPoint(Size P){ _X = P.Width; _Y = P.Height; }
    public FloatPoint(SizeF P){ _X = P.Width; _Y = P.Height; }

#region Obj
    // Object ====================================
    public FloatPoint Clone(){ return (new FloatPoint(X,Y)); }
    public void CopyPoint(FloatPoint inPoint) { X=inPoint.X; Y=inPoint.Y; }
    public override string ToString() { return String.Format("HPoint:X:{0},Y:{1}",X,Y); }
#endregion

#region IComparable
    int IComparable.CompareTo(object obj)
    {
      FloatPoint o = FloatPoint.Empty;
      if (!(obj is FloatPoint)) return 0;
      else
      {
        o = (FloatPoint) obj;
      }
      if (o.Equals(FloatPoint.Empty)) return 0;
      if (this < o) return -1;
      if (this > o) return 1;
      return 0;
    }
#endregion
  }

	//
	public class DPoint
	{
		static public DPoint Empty { get { return new DPoint(0D); } }
		static public DPoint One { get { return new DPoint(1D); } }
		
		double _X=0f, _Y=0f;
		[XmlAttribute] public double X { get { return _X; } set { _X = value; } }
		[XmlAttribute] public double Y { get { return _Y; } set { _Y = value; } }
		
#region Properties
		[XmlIgnore] public double Bigger { get { return (X >= Y)? X: Y; } }
		[XmlIgnore] public bool IsLand { get { return X >= Y; } }
		/// <summary>zerod’</summary>
		[XmlIgnore] public double Slope { get  { return Math.Sqrt(Math.Pow(X,2)+Math.Pow(Y,2)); }  }
#endregion
#region Static Methods
		static public DPoint FlattenPoint(DPoint _pin, bool roundUp)
		{
			DPoint newP = _pin.Clone();
			if (newP.X==newP.Y) return newP;
			if (_pin.X > _pin.Y) { if (roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			else { if (!roundUp) newP.Y = newP.X; else newP.X = newP.Y; }
			return newP;
		}
		static public DPoint FlattenPoint(DPoint _pin) { return FlattenPoint(_pin,false); }
		/// <summary>same as FlattenPoint overload without boolean</summary>
		static public DPoint FlattenDown(DPoint _pin) { return FlattenPoint(_pin); }
		static public DPoint FlattenUp(DPoint _pin) { return FlattenPoint(_pin,true); }
#endregion
#region Helpers “Obsolete?”
		//public double Slope() { return Hypotenuse; }
		//public double Sine { get { return Y/Hypotenuse; } }
		//public double Cosine { get { return X/Hypotenuse; } }
		//public double Tangent { get { return Y/X; } }
		//public double SlopeRatio(XPoint cmp) { return Slope()/cmp.Slope); }
		/// <summary>Returns a new flattened point</summary>
		public DPoint Flat(bool roundUp) { return FlattenPoint(this,roundUp); }
		/// <summary>Flattens the calling point</summary>
		public void Flatten(bool roundUp) { DPoint f = Flat(roundUp); this.X = f.X; this.Y = f.Y; f = null; }
		/// <summary>use Flat or flatten calls.</summary>
		public DPoint ScaleTo(DPoint point)
		{
			if (point.X==X && point.Y==Y) throw new InvalidOperationException("you mucker");
			//System.Windows.Forms.MessageBox.Show( string.Format("X: {1},Y: {0}",Y/point.Y,X/point.X) );
			if (X > point.Y)
			{
#if CONSOLE && COR3
				Global.cstat(ConsoleColor.Red,"X is BIGGER");
#else
				Debug.Print("X is BIGGER");
#endif
			}
#if CONSOLE && COR3
			else Global.cstat(ConsoleColor.Red,"X is SMALLER");
#else
			else Debug.Print("X is SMALLER");
#endif
			return this;
		}
		public DPoint GetRation(DPoint dst)
		{
			return dst/this;
		}
		public DPoint GetScaledRation(DPoint dst)
		{
			return this*(dst/this);
		}
		public double Dimension() { return X*Y; }
#endregion
#region Help
		public DPoint Translate(DPoint offset, DPoint zoom)
		{
			return (this+offset)*zoom;
		}
		public DPoint Translate(double offset, double zoom)
		{
			return (this+new DPoint(offset*zoom));
		}
#endregion
#region Maths
		public bool IsXG(DPoint P) { return X>P.X; }
		public bool IsYG(DPoint P) { return Y>P.Y; }
		public bool IsXL(DPoint P) { return X<P.X; }
		public bool IsYL(DPoint P) { return Y<P.Y; }
		
		public bool IsLEq(DPoint p) { return (X<=p.X) && (Y<=p.Y); }
		public bool IsGEq(DPoint p) { return (X>=p.X) && (Y>=p.Y); }
		
		public bool IsXGEq(DPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYGEq(DPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXLEq(DPoint P) { return IsXG(P)&IsXG(P); }
		public bool IsYLEq(DPoint P) { return IsYG(P)&IsYG(P); }
		public bool IsXEq(DPoint P) { return X==P.X; }
		public bool IsYEq(DPoint P) { return Y==P.Y; }
		
		public DPoint Multiply(params DPoint[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new DPoint(X,Y)*P[0];
			DPoint NewPoint = new DPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public DPoint Multiply(params float[] P) {
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new DPoint(X,Y)*P[0];
			DPoint NewPoint = new DPoint(X,Y)*P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint *= P[i];
			}
			return NewPoint;
		}
		public DPoint Divide(params DPoint[] P)
		{
			if (P.Length==0) throw new ArgumentException("there is no data!");
			if (P.Length==1) return new DPoint(X,Y)/P[0];
			DPoint NewPoint = new DPoint(X,Y)/P[0];
			for (int i = 1; i < P.Length; i++)
			{
				NewPoint /= P[i];
			}
			return NewPoint;
		}
		public DPoint MulX(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.X *= RefPoint.X;
			return PBase;
		}
		public DPoint MulY(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.Y *= RefPoint.Y;
			return PBase;
		}
		public DPoint DivX(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.X /= RefPoint.X;
			return PBase;
		}
		public DPoint DivY(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.Y /= RefPoint.Y;
			return PBase;
		}
		public DPoint AddX(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.X += RefPoint.X;
			return PBase;
		}
		public DPoint AddY(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.Y += RefPoint.Y;
			return PBase;
		}
		public DPoint AddY(params int[] P)
		{
			DPoint PBase = Clone();
			foreach (int RefPoint in P) PBase.Y += RefPoint;
			return PBase;
		}
		public DPoint NegX(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.X -= RefPoint.X;
			return PBase;
		}
		public DPoint NegX(params int[] P)
		{
			DPoint PBase = Clone();
			foreach (int Ref in P) PBase.X -= Ref;
			return PBase;
		}
		public DPoint NegY(params DPoint[] P)
		{
			DPoint PBase = Clone();
			foreach (DPoint RefPoint in P) PBase.Y -= RefPoint.Y;
			return PBase;
		}
		public DPoint NegY(params int[] P)
		{
			DPoint PBase = Clone();
			foreach (int Ref in P) PBase.Y -= Ref;
			return PBase;
		}
#endregion
#region Static Methods
		static public DPoint Average(params DPoint[] xp)
		{
			DPoint p = new DPoint(0);
			foreach (DPoint pt in xp) p += pt;
			return p/xp.Length;
		}
#if WFORMS
    static public DPoint GetClientSize(Control ctl) { return ctl.ClientSize; }
		static public DPoint GetPaddingTopLeft(Padding pad) { return new DPoint(pad.Left,pad.Top); }
		static public DPoint GetPaddingOffset(Padding pad) { return new DPoint(pad.Left+pad.Right,pad.Top+pad.Bottom); }
#endif
		// =======================================================
		static public DPoint Angus(float offset, float ration, float phase) { return new DPoint(-Math.Sin(cvtf(ration,offset+phase)),Math.Cos(cvtf(ration,offset+phase))); }
		static public DPoint Angus(float offset, float ration) { return Angus(offset,ration,0.0f); }
		static float cvtf(float S, float I){ return (float)((Math.PI*2)*(I/S)); }
		// =======================================================
		/// • AutoScale — multiplies agains largest point in “dest / source”
		static public DPoint Fit(DPoint dest, DPoint source)
		{
			return Fit(dest,source,scaleFlags.autoScale);
		}
		/// • AutoScale — Multiplies against largest source size: ( ( source.X | source.Y ) * ( dest / source.X | source.Y ) )<br/>•
		/// ScaleWidth ( dest * source.X )
		static public DPoint Fit(DPoint dest, DPoint source, scaleFlags sf)
		{
			DPoint HX = dest/source;
			if (sf== scaleFlags.autoScale) return (HX.Y > HX.X) ? source*HX.X : source * HX.Y;
			else return (sf== scaleFlags.sWidth) ? source*HX.X : source*HX.Y;
		}
		
#endregion
#region Operators
		static public DPoint operator +(DPoint a, DPoint b){ return new DPoint(a.X+b.X,a.Y+b.Y); }
		static public DPoint operator +(DPoint a, Point b){ return new DPoint(a.X+b.X,a.Y+b.Y); }
		static public DPoint operator +(DPoint a, int b){ return new DPoint(a.X+b,a.Y+b); }
		static public DPoint operator +(DPoint a, float b){ return new DPoint(a.X+b,a.Y+b); }
		static public DPoint operator +(DPoint a, double b){ return new DPoint(a.X+b,a.Y+b); }
		static public DPoint operator -(DPoint a){ return new DPoint(-a.X,-a.Y); }
		static public DPoint operator -(DPoint a, DPoint b){ return new DPoint(a.X-b.X,a.Y-b.Y); }
		static public DPoint operator -(DPoint a, Point b){ return new DPoint(a.X-b.X,a.Y-b.Y); }
		static public DPoint operator -(DPoint a, int b){ return new DPoint(a.X-b,a.Y-b); }
		static public DPoint operator -(DPoint a, float b){ return new DPoint(a.X-b,a.Y-b); }
		static public DPoint operator -(DPoint a, double b){ return new DPoint(a.X-b,a.Y-b); }
		static public DPoint operator /(DPoint a, DPoint b){ return new DPoint(a.X/b.X,a.Y/b.Y); }
		static public DPoint operator /(DPoint a, Point b){ return new DPoint(a.X/b.X,a.Y/b.Y); }
		static public DPoint operator /(DPoint a, int b){ return new DPoint(a.X/b,a.Y/b); }
		static public DPoint operator /(DPoint a, float b){ return new DPoint(a.X/b,a.Y/b); }
		static public DPoint operator /(DPoint a, double b){ return new DPoint(a.X/b,a.Y/b); }
		static public DPoint operator *(DPoint a, DPoint b){ return new DPoint(a.X*b.X,a.Y*b.Y); }
		static public DPoint operator *(DPoint a, Point b){ return new DPoint(a.X*b.X,a.Y*b.Y); }
		static public DPoint operator *(DPoint a, int b){ return new DPoint(a.X*b,a.Y*b); }
		static public DPoint operator *(DPoint a, float b){ return new DPoint(a.X*b,a.Y*b); }
		static public DPoint operator *(DPoint a, double b){ return new DPoint(a.X*(float)b,a.Y*(float)b); }
		static public DPoint operator %(DPoint a, DPoint b){ return new DPoint(a.X%b.X,a.Y%b.Y); }
		static public DPoint operator %(DPoint a, Point b){ return new DPoint(a.X%b.X,a.Y%b.Y); }
		static public DPoint operator %(DPoint a, int b){ return new DPoint(a.X % b,a.Y % b); }
		static public DPoint operator %(DPoint a, float b){ return new DPoint(a.X % b,a.Y % b); }
		static public DPoint operator %(DPoint a, double b){ return new DPoint(a.X % b,a.Y % b); }
		static public DPoint operator ++(DPoint a){ return new DPoint(a.X++,a.Y++); }
		static public DPoint operator --(DPoint a){ return new DPoint(a.X--,a.Y--); }
		static public bool operator >(DPoint a,DPoint b){ return ((a.X>b.X) & (a.Y>b.Y)); }
		static public bool operator <(DPoint a,DPoint b){ return ((a.X<b.X) & (a.Y<b.Y)); }
#endregion
#region Operators Implicit
		static public implicit operator Point(DPoint a){ return new Point((int)a.X,(int)a.Y); }
		static public implicit operator PointF(DPoint a){ return new PointF((float)a.X,(float)a.Y); }
		static public implicit operator Size(DPoint a){ return new Size((int)a.X,(int)a.Y); }
		static public implicit operator SizeF(DPoint a){ return new SizeF((float)a.X,(float)a.Y); }
		static public implicit operator DPoint(Size s){ return new DPoint(s); }
		static public implicit operator DPoint(SizeF s){ return new DPoint(s); }
		static public implicit operator DPoint(Point s){ return new DPoint(s); }
		static public implicit operator DPoint(PointF s){ return new DPoint(s); }
#endregion
		
		public DPoint(){ }
		public DPoint(double x, double y){ _X = x; _Y = y; }
		public DPoint(int value) : this(value,value) {  }
		public DPoint(long value) : this(value,value) {  }
		public DPoint(float value) : this((double)value,(double)value) {  }
		public DPoint(double value) : this(value,value) {  }
		public DPoint(FloatPoint value) : this(value.X,value.Y) {  }
		public DPoint(Point P){ _X = P.X; _Y = P.Y; }
		public DPoint(PointF P){ _X = P.X; _Y = P.Y; }
		public DPoint(Size P){ _X = P.Width; _Y = P.Height; }
		public DPoint(SizeF P){ _X = P.Width; _Y = P.Height; }
		
#region Object
		public DPoint Clone(){ return new DPoint(X,Y); }
		public void CopyPoint(DPoint inPoint) { X=inPoint.X; Y=inPoint.Y; }
		public override string ToString() { return String.Format("XPoint:X:{0},Y:{1}",X,Y); }
#endregion
		
	}

}
