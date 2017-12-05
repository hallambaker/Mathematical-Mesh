The Documentation Build Project
===============================

A key objective of the PHB build tools environment is to ensure that the
documentation, examples and reference code are kept in lockstep. To make
this happen, the following conventions are observed:

Documentation
    Holds the source documents and the example code generation project.

Documentation/Examples
    Holds the text data generated from running the test program

Documentation/Generated
    Holds reference text that was generated from the .protocol specification
	files

Documentation/Static
    Holds static text data that should remain the same between versions
	of the documentation. For example files holding private key material.

Documentation/Publish
    Holds the output of the document processors (.txt, .html and .xml)


The build process has three phases:

1) Prebuild.bat is run
	Deletes Version.cs, and everything in Examples, Generated and Publish
	Runs the reference documentation generation tools
	Runs ExampleGenerator.exe which create the examples an new copy of Version.cs.

2) The class library Documentation.dll is built
	This is actually a dummy target right now, the only purpose
	being to cause the documentation build to fail if the examples

3) Postbuild.bat is run
	This generates the output files for publication.

The objective of this build process is to ensure that the output documents
are only created if ExampleGenerator.exe runs successfully. If 
ExampleGenerator.exe does not exist or does not run to completion, no
output files are generated.

Note that support for future versions of the document format will probably 
require that each publication target is created in its own separate
directory along with additional content for inclusion such as images,
code samples, etc.