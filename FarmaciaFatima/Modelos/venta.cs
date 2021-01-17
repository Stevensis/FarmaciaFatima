using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FarmaciaFatima.Modelos
{
    class venta
    {
        public TextBox texto;
        public string idBodega;
        public string presentacion;
        public TextBox cantidad;
        public Panel panel;
        public Panel temp;
        public Button quitar;
        public int posY;
        public string precio;
        public string stock;
        List<venta> lstVentas;
        public string tipo;
        public string representacion;
        public string CasaMedica;

        public int VCantidad;
        public float Vsubtotal;
        public int Vrestado;

        public venta(string idBodega, Panel panel, int posY, string textoC, string presentacion, string CasaMe, string stock, string precio, List<venta> lstVentas, string tipo, string representa)
        {
            this.idBodega = idBodega;
            this.panel = panel;
            this.posY = posY;
            this.texto = new TextBox();
            this.cantidad = new TextBox();
            this.texto.Text = textoC + " " + presentacion + " / " + CasaMe + " / Q"+precio;
            this.quitar = new Button();
            this.temp = new Panel();
            this.presentacion = presentacion;
            this.panel =panel;
            this.stock = stock;
            this.precio = precio;
            this.lstVentas = lstVentas;
            this.tipo = tipo;
            this.representacion = representa;
            this.CasaMedica = CasaMe;


            Inicializador();
        }

        public void Inicializador() {

            this.texto.Location = new System.Drawing.Point(10, 3);
            this.texto.Font = new Font("Lucida Sans Unicode", 8, FontStyle.Regular);
            this.texto.Size = new System.Drawing.Size(700, 10);
            this.texto.Enabled = false;
            this.temp.Controls.Add(this.texto);

            this.cantidad.Location = new System.Drawing.Point(755, 3);
            this.cantidad.Font = new Font("Lucida Sans Unicode", 8, FontStyle.Regular);
            this.cantidad.Size = new System.Drawing.Size(30, 10);
            this.temp.Controls.Add(this.cantidad);
            this.cantidad.KeyPress += (sender, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            this.quitar.Location = new System.Drawing.Point(830, 3);
            this.quitar.Font = new Font("Lucida Sans Unicode", 8, FontStyle.Regular);
            this.quitar.Text = "X";
            this.quitar.Size = new System.Drawing.Size(25, 25);
            this.quitar.Click += (sender, args) =>
            {
                this.panel.Controls.Remove(this.temp);
                this.lstVentas.Remove(this);
               
            };
            this.temp.Controls.Add(this.quitar);
            this.temp.Size = new System.Drawing.Size(900, 27);
            this.temp.Dock = DockStyle.Top;
            this.panel.Controls.Add(this.temp);

        }

        public bool sePuedeVender() {

            try
            {
                if (this.tipo.Equals("2")) {
                    if ((int.Parse(this.stock) - int.Parse(this.cantidad.Text)) >= 0)
                    {
                        this.VCantidad = int.Parse(this.cantidad.Text);
                        this.Vrestado = int.Parse(this.cantidad.Text);
                        return true;
                    }
                }
                else if(this.tipo.Equals("1")){
                    if ((int.Parse(this.stock) - int.Parse(this.cantidad.Text)) >= 0)
                    {
                        this.VCantidad = int.Parse(this.cantidad.Text);
                        this.Vrestado = int.Parse(this.cantidad.Text)*int.Parse(this.representacion);
                        return true;
                    }
                }
                
            }
            catch (Exception)
            {

                return false;
            }
            
            
            return false;
        }

        


    }
}
