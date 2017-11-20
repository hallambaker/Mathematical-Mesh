	// split a command line into chunks applying windows command line escaping rules
	//
	// one two		-> [one] [two]
	// "one two"	-> [one two]
	// "one"two"	-> [onetwo]
	// "one""two"	-> [one"two]
	// \\			-> [\\]
	// \\"			-> [\"]
	// \\" \\		-> [\ \\]
	// \\\" \\		-> [\"] [\\]
	// "Test""Here"	-> [TestHere]
	// Test""Here	-> [Test"Here]]


	"" Test-> [] [Test]