# Considerations for GUI reference app

Since each platform has its own user interface, any cross platform application
must decide how to access features such as 

* Window system

* Camera/Microphone

* Video/Audio encoding

The best choice is inevitably a moving target Microsoft .NET supports a very wide
range of platforms but does so through two separate frameworks that are still in
the process of being merged.


# Window System - Maui


# Browser Subsystem - Blazor


# Camera input - USB Camera

This is a pro tem windows only solution at the moment.


# Video encoding - OpenH264Lib

https://github.com/secile/OpenH264Lib.NET

Recording using AVI writer:

https://github.com/secile/MotionJPEGWriter/blob/master/source/AviWriter.cs