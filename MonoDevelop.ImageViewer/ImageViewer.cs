//
//  ImageViewer.cs
//
//  Author:
//       Jean-Philippe Bruyère <jp.bruyere@hotmail.com>
//
//  Copyright (c) 2015 jp
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

// 
// HexEditorView.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.IO;
using MonoDevelop.Ide.Gui;
using MonoDevelop.Ide.Gui.Content;
using Xwt;
using MonoDevelop.Ide.Fonts;
using Mono.Addins;
using MonoDevelop.Core;
using MonoDevelop.Ide;
using Xwt.Drawing;

namespace MonoDevelop.ImageViewer
{
	class ImageViewer : AbstractXwtViewContent//, IZoomable
	{		
		ScrollView window ;
		ImageView iView;
		Image 	scaledImg,
				origImg;

		double zoom = 1.0;
		
		public override Xwt.Widget Widget {
			get {
				return window;
			}
		}

		public ImageViewer ()
		{			
			iView = new ImageView ();
			window = new ScrollView (iView);
		}

		public override void Load (string fileName)
		{	
			
			origImg = Xwt.Drawing.Image.FromFile (fileName);
			update ();
			iView.Image = scaledImg;
			ContentName = fileName;
			this.IsDirty = false;
			window.SetFocus ();
		}

		void update ()
		{
			scaledImg = origImg.Scale (zoom, zoom);
//			this.IsDirty = true;
//			this.Widget.QueueForReallocate ();
//			this.RedrawContent ();
		}
//		#region IZoomable implementation
//
//		public void ZoomIn ()
//		{
//			zoom *= 2.0;
//			update ();
//		}
//
//		public void ZoomOut ()
//		{
//			zoom /= 2.0;
//			update ();
//		}
//
//		public void ZoomReset ()
//		{
//			zoom = 1.0;
//			update ();
//		}
//
//		public bool EnableZoomIn {
//			get {
//				return scaledImg == null ? false : true;
//			}
//		}
//
//		public bool EnableZoomOut {
//			get {
//				return scaledImg == null ? false : true;			
//			}
//		}
//
//		public bool EnableZoomReset {
//			get {
//				return scaledImg == null ? false : true;
//			}
//		}
//
//		#endregion
	}
}
