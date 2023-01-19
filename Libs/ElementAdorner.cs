using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using WpfLib.Extensions;

namespace WpfDragAndDrop.Libs
{
  public class ElementAdorner : Adorner
  {
    private Rect _renderRect;
    private Point _offset;
    private ImageSource _imageSource;

    public ElementAdorner(FrameworkElement adornedElement) : base(adornedElement)
    {
      IsHitTestVisible = false;
      Opacity = 0.7;
      
      _renderRect = new Rect(adornedElement.RenderSize);
      _offset = new Point(-this._renderRect.Width / 2, -this._renderRect.Height / 2);
      // element 이미지로 변경
      using System.Drawing.Bitmap bmp = adornedElement.ToBitmap();
      _imageSource = bmp.ToImageSource();
    }

    public void SetArrange(Visual visual)
    {
      System.Drawing.Point cursorPoint = System.Windows.Forms.Cursor.Position;
      Point point = visual.PointFromScreen(new Point(cursorPoint.X + _offset.X, cursorPoint.Y + _offset.Y));
      Arrange(new Rect(point, DesiredSize));
    }

    protected override void OnRender(DrawingContext drawingContext)
    {
      drawingContext.DrawImage(_imageSource, _renderRect);
    }
  }
}
