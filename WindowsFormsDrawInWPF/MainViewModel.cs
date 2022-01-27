using BindingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WindowsFormsDrawInWPF
{
    public class MainViewModel : NotifyPropertyBase
    {
        public System.Windows.Forms.Panel WinPanel { get; set; }

        public ICommand DrawCommand
        {
            get
            {
                return new RelayCommand((x) =>
                {
                    if (WinPanel == null) { return; }
                    Draw(System.Drawing.Color.Blue, new System.Drawing.Rectangle(0, 0, 100, 100));
                });
            }
        }

        private void Draw(System.Drawing.Color color, System.Drawing.Rectangle rect)
        {
            using (var myBrush = new System.Drawing.SolidBrush(color))
            {
                using (var formGraphics = WinPanel.CreateGraphics())
                {
                    formGraphics.Clear(System.Drawing.Color.White);
                    formGraphics.FillEllipse(myBrush, rect);
                }
            }
        }
    }
}
