# XVGML engine
**eXtensible Vector Graphics Markup Language**

This is a very old project I did about the time when XAML started to see the light. The idea turned out to be very similar - you define elements in XML and they are then being rendered into an image. Although this project was mostly focusing on rendering images (compared to XAML, focusing on interactive UI), I decided to ditch it anyway, as XAML could be used (and has) vector graphic resources as well. This is fully working project, although number of implemented graphical elements is very limited. Today even Google has primitive vector drawables in their Android framework.

Code composition works through *packages*, which can register one or more graphical elements (with XML namespace and name) in the container. Then `LayoutBuilder` can instantiate all elements based on the registrations and `LayoutRenderer` can render them on the `ICanvas`. Cool feature is that there could be multiple canvas implementations. Default one is using standard **GDI**, while one can implement hardware-accelerated **DirectDraw** canvas, if necessary.

This was a fun project to get hands-on experience creating 2D image format, rendering engine and understanding all potential complications.

`Test` project is a console app that has few sample XML image definitions and can render them in PNG format.

Happy coding!