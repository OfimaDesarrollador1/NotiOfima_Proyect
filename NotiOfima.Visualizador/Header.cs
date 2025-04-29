using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace NotiOfima.Visualizador
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        // Propiedad para almacenar el control ofima seleccionado
        public string titulo
        {
            get
            {
                return lblTitulo.Text;
            }
            set
            {
                lblTitulo.Text = value;
            }
        }
    }
}
