# CopyCalibreCovers (WinForms)

This program provides calibre book cover images to a destination.

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

    LibraryCollection Libraries = new LibraryCollection(
		@"f:/Horde/Library",
		@"d:/dev/www/pub/books/assets",
		"Library, Comic",
		"Library, Dev",
		"Library, Ebook",
		"Library, Fiction",
		"Library, Images",
		"Library, Mag",
		"Library, New",
		"Library, SSOC",
		"Library, The",
		"Library, Topical"
	);