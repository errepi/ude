Ude is a C# port of [Mozilla Universal Charset Detector](http://mxr.mozilla.org/mozilla/source/extensions/universalchardet/src/).

The article ["A composite approach to language/encoding detection"](http://www.mozilla.org/projects/intl/UniversalCharsetDetection.html) describes the charsets detection algorithms implemented by the library.

Ude can recognize the following charsets:

  * UTF-8
  * UTF-16 (BE and LE)
  * UTF-32 (BE and LE)
  * windows-1252 (_mostly_ equivalent to iso8859-1)
  * windows-1251 and ISO-8859-5 (cyrillic)
  * windows-1253 and ISO-8859-7 (greek)
  * windows-1255 (logical hebrew. Includes ISO-8859-8-I and most of x-mac-hebrew)
  * ISO-8859-8 (visual hebrew)
  * Big-5
  * gb18030 (superset of gb2312)
  * HZ-GB-2312
  * Shift-JIS
  * EUC-KR, EUC-JP, EUC-TW
  * ISO-2022-JP, ISO-2022-KR, ISO-2022-CN
  * KOI8-R
  * x-mac-cyrillic
  * IBM855 and IBM866
  * X-ISO-10646-UCS-4-3412 and X-ISO-10646-UCS-4-2413 (unusual BOM)
  * ASCII

## Platform ##

Windows and Linux (Mono)

## Install ##

The release consists in the main library (_Ude.dll_) and a command-line client (udetect.exe) that can be used for one-shot tests.

On Windows, compile the Visual Studio 2005 solution _ude.sln_.
On Linux you can build the library, the example and the nunit tests with monodelop
and its solution _ude.mds_, or using _make_. To compile the sources tarball:

```
    $ ./configure.sh --prefix=/usr/local --enable-tests=yes
    $ make
```

To compile from svn:

```
   $ ./autogen.sh --prefix=/usr/local --enable-tests=yes
   $ make
```

You can pick the library (Ude.dll) from the toplevel build directory (./bin) or
you can install it to _$prefix_/lib/ude by typing:

```
   $ make install
```

This will installs a command-line example program (_$prefix_/bin/udetect) to test
the library on a given file as:

```
   $ udetect filename 
```

To run the nunit tests type:

```
    $ make test
```

## Usage ##



## Example ##

```

    public static void Main(String[] args)
    {
        string filename = args[0];
        using (FileStream fs = File.OpenRead(filename)) {
            Ude.CharsetDetector cdet = new Ude.CharsetDetector();
            cdet.Feed(fs);
            cdet.DataEnd();
            if (cdet.Charset != null) {
                Console.WriteLine("Charset: {0}, confidence: {1}", 
                     cdet.Charset, cdet.Confidence);
            } else {
                Console.WriteLine("Detection failed.");
            }
        }
    }    
```

## Other portings ##

The original Mozilla Universal Charset Detector has been ported to a variety of languages. Among these, a Java port:

  * [juniversalchardet](http://code.google.com/p/juniversalchardet/)

from which I copied a few data structures, and a Python port:

  * [chardet](http://chardet.feedparser.org/) (in Python)

## License ##

The library is subject to the Mozilla Public License Version 1.1 (the "License"). Alternatively, it may be used under the terms of either the GNU General Public License Version 2 or later (the "GPL"), or the GNU Lesser General Public License Version 2.1 or later (the "LGPL").

Test data has been extracted from [Wikipedia](http://www.wikipedia.org) and [The Project Gutenberg](http://www.gutenberg.org) books and is subject to [their](http://en.wikipedia.org/wiki/Wikipedia:Text_of_the_GNU_Free_Documentation_License) [licenses](http://www.gutenberg.org/wiki/Gutenberg:The_Project_Gutenberg_License).

