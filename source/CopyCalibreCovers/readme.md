# CopyCalibreCovers (WinForms)

This program provides Calibre book cover images to a destination.

Exemplified is a phase from the initial concept,
half-way though to a newer concept.

- The result is shadey.
- You pretty much would have to modify the source, and compile
  to really enjoy using it.
- But again, “it works”

----

**In the future**

I would like a simple configuration to be provided somewhat
semblant to a CMake UI... Maybe I should have written this in


- where is your assets library?
    - drag-drop the directory to a UI.

## Books and their respective directories

Example Library base-path

    c:\mylibraries
    
containing several sub-directories which contain calibre libraries.

    c:\mylibraries\library one\
    
in the above directory would be Calibre's metadata.db

    c:\mylibraries\library one\metadata.db

## The LibraryCollection

the idea is to provide something like the following LibraryCollection (which is
simply a Generic.List<string> with one input and one output path added).

Currently this is hard-coded into the app as I roll out a automated process
allowing for import/export of settings.

```js
LibraryCollection Libraries = new LibraryCollection(
	@"f:/Horde/Library",
	@"d:/dev/www/pub/books/assets",
	"Comic",
	"Dev",
	"Ebook",
	"Fiction",
	"Images",
	"Mag",
	"New",
	"Non-Fiction",
	"SSOC",
	"The",
	"Topical"
);
```

**20140902** A simple task list

- Look at [vaio/bookapp/api](http://vaio/bookapp/api/)
- Should rather be looking at: [vaio/bookapp/conf](http://vaio/bookapp/conf)
- We need somehow to detect 
- I'm on my third reader html application.
- This time via a yo-generated bower template and I like.
- CopyCalibreCovers is working again, **though it really can not rebuild its data**.