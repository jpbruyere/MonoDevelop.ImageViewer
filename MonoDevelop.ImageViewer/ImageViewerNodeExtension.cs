// 
// ImageViewerNodeExtension.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2010 Novell, Inc (http://www.novell.com)
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
using MonoDevelop.Projects;
using MonoDevelop.Ide.Gui.Components;
using MonoDevelop.Components;
using MonoDevelop.Components.Commands;
using MonoDevelop.Ide;
using Xwt.Drawing;
using Xwt;

namespace MonoDevelop.ImageViewer
{
	enum Commands {
		ShowImageViewer
	}
	
	class ImageViewerNodeExtension : NodeBuilderExtension
	{		
		public override Type CommandHandlerType {
			get { return typeof(ImageViewerCommandHandler); }
		}
		public override bool CanBuildNode (Type dataType)
		{			
			return typeof(ProjectFile).IsAssignableFrom (dataType);
		}
		public override void BuildNode (ITreeBuilder treeBuilder, object dataObject, NodeInfo nodeInfo)
		{
			ProjectFile pf  = dataObject as ProjectFile;

			string mimeType = DesktopService.GetMimeTypeForUri (pf.FilePath);
			if (mimeType.StartsWith ("image/", StringComparison.CurrentCultureIgnoreCase)) {
				Image i;
				if (pf != null) {				
					i = Image.FromFile (pf.FilePath);
					nodeInfo.Icon = i.Scale (16.0 / i.Width, 16.0 / i.Height);
				}
			}

			base.BuildNode (treeBuilder, dataObject, nodeInfo);
		} 
	}
	
	class ImageViewerCommandHandler: NodeCommandHandler 
	{
		[CommandHandler (Commands.ShowImageViewer)]
		protected void OnShowImageViewer () 
		{

			ImageViewer view = new ImageViewer ();

			ProjectFile file   = CurrentNode.DataItem as ProjectFile;
			if (file != null)
				view.Load (file.FilePath);
			
			IdeApp.Workbench.OpenDocument (view, true);
		}
	}

}

