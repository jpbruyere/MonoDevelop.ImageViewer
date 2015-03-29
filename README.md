**MonoDevelop.ImageViewer**

Image viewer addin for MonoDevelop. 
Use image preview as icon in project pad, and open image in a simple viewer when double-clicked.


Compiling
---------

Ensure **PKG_CONFIG_PATH** point where monodevelop.pc is installed. for example, 
if --prefix for installation of MD was /usr/local
`export PKG_CONFIG_PATH=/usr/local/lib/pkgconfig`

Then, build with:
`cd MonoDevelop.ImageViewer`
`xbuil MonoDevelop.ImageViewer.csproj`
