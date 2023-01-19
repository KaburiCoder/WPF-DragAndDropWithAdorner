using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfDragAndDrop.Libs;

namespace WpfDragAndDrop.Controls
{
  /// <summary>
  /// DragControl.xaml에 대한 상호 작용 논리
  /// </summary>
  public partial class DragControl : UserControl
  {
    private ElementAdorner _elementAdorner = default!;

    public DragControl()
    {
      InitializeComponent();
      MouseMove += DragControl_MouseMove;
      PreviewGiveFeedback += DragControl_PreviewGiveFeedback;
    }

    private void DragControl_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e)
    {
      _elementAdorner.SetArrange(this);
    }

    private void DragControl_MouseMove(object sender, MouseEventArgs e)
    {
      AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(this);
      _elementAdorner = new ElementAdorner(this);
      adornerLayer.Add(_elementAdorner);

      DragDrop.DoDragDrop(this, Background, DragDropEffects.Copy);

      adornerLayer.Remove(_elementAdorner);
    }
  }
}
