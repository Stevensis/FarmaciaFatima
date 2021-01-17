using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FarmaciaFatima.Procesos;

namespace FarmaciaFatima.Ventanas
{
    public partial class ReporteVentas : Form
    {
        public ReporteVentas()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
            GC.Collect();
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            Maximizar.Visible = false;
            restaurar.Visible = true;
        }

        private void restaurar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            restaurar.Visible = false;
            Maximizar.Visible = true;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CrearReporte reporte = new CrearReporte();
            reporte.reporteVentas(dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            
        }
    }
}
