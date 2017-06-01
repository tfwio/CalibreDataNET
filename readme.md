<!-- title: CalibreDataNET
subtitle: Calibre (ebook software) Database Utility written for DotNET
date: 2014-07–2017
author: tfwio -->

Here there are a few examples of how to use Calibre's SQLite3 databases wired up into three basic applications...

1. **CalibreData**: is the 'common' library carries bulk data and image utililty operations/abstractions.
2. **BookApp** `books.csproj`: A general MVC-WebApp (DotNet v4.0, MVC v4.0, WebPages v2.0)
3. **CopyCalibreImages**: A Windows.Forms app which abstracts thumbnails from your Calibre libraries provided a JSON configuration file, `conf.json`.
4. A general **TestApp** simply exists to point one in the right direction when it comes to generating JSON content from the command-line similarly to the way the MVC-web-app does.

# MVC WebApp Interface API

The basic general scope of the MVC app is to provide a JSON response provided specific request syntax so that one can build a SPA (Single Page Application) or some-such.  HTTP responses will either be JSON-data mirrored from the respective `metadata.db` in your e-book library-directory, or a e-book download.

Before listing the few API, note that this tool expects that you have multiple Calibre book-libraries in paralell to one another in a given 'root' directory.  That is to say that within `[library-root-path]`, we may have several sub-directories and each of those sub-directories is a Calibre library.

If you have only one Calibre e-book library, then just use it's parent directory as the library-root and configure only the one library.

- `~/api/[category]` where **category** is the name of your library (sub-directory)
- `~/api/book/[category]/[index]/[format]/`: This is used to download your book in the provided format.  This layer of the API is expected to be generated from our data-set which tells us what book formats are available, the book-id (index) and etc...
    - `category`: as seen above, this is the target "library-path-name".
    - `index`: the book index or 'id' for the book as indexed into the database.  (this same index corresponds to the generated images in the CopyCalibreCovers Windows.Forms app).
    - `format`: the supported book format.


# CopyCalibreCovers and its Config-File

This app was written (and most everything else presented here) from some strange tinker-mentallity where I'd been playing with windows-forms binding methodology a bit (among other things).  Note that most if not all the main-menu (in the menu-bar) items do NOTHING.  Some of the features (like the +/- buttons) are kind of useless, but once you write up a working configuration file (or change the existing one), the program will allow you to generate thumbnails from your Calibre library covers.

Each image is named for the INDEX of the book as it is listed within the `metadata.db` for the library, so you can look up the image by the index of your book from another script or application.

Config file is copied parallel to the application `CopyCalibreCovers.exe` on build and is loded when the program launches.

- `libroot`: The directory containing your calibre-library directories.  just to be clear, each calibre-library directoriy contains a `metadata.db` file.
- `imgroot`: is the target export directory.  Do be sure this directory exists—I'm thinking it doesn't auto-generate.
- `dirs`: these are the sub-directories as can be found in `lib-root` which are allowed to be generated from within the application.

**conf.json example**
```json
{
"libroot":"e:/serve/book",
"imgroot":"e:/serve/book-cover",
"dirs":[
  "Library-One",
  "Library-Two",
  "Library-Three",
  // ...,
  "Library-N"
]}
```

## TestApp

A command-line demo app allows for two little options and may have the following parameters...

- `-p` (optional) tells the program to pause before exiting
- `-s` (optional) tells the program to `SimplifyOutput` which omits the query from the 'response' (output) and tabifies (prettifies) the resulting JSON output for human reading.
- the last parameter must be the full path to your `metadata.db` file.  Any option before the db file will be ignored if not listed above.

# BEFORE YOU COMPILE

Until further updates, there are a few hard-coded areas that need to be changed to suit your Calibre library (location).

- Make sure you modify/update the conf.json file in the main source directory (`[clone-path]\source\conf.json`).
- `[clone-path]\source\CalibreData\source\models\bookrequest.cs`  
  static string libroot is hard-coded to a directory that doesn't even exist on my machine.  You can set it as you like.  
  Note: within the MVC-web-app's startup operation, we over-ride this with a call to `BookRequest.SetRoot([your-lib-root])`.
- I had cloned https://github.com/subtlepatterns/SubtlePatterns into the mvc-book-app assets dir:  
  `[this-repo]\source\Books\Assets\subtlepatterns`



