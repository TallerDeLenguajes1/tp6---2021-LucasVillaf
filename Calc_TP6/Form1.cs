using Calc_TP6.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Calc_TP6
{
    public partial class Form1 : Form
    {
        float resultado = 0;
        string operacion;
        string valor1 = null; //variable de control
        string valor2 = null; //variable de control

        //Instancias
        Suma miSuma = new Suma();
        Resta miResta = new Resta();
        División miDivisíon = new División();
        Producto miProducto = new Producto();
        Calculadora nuevaCalculadora = new Calculadora();

        //Cultura para punto decimal
        CultureInfo nuevaCultura = new CultureInfo("us-US");

        //lista para historial de resultados
        List<Calculadora> Historial = new List<Calculadora>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnNum1_Click(object sender, EventArgs e)
        {
            //botón numero 1
            txtBoxScreen.Text += "1";
        }

        private void btnNum2_Click(object sender, EventArgs e)
        {
            //botón numero 2
            txtBoxScreen.Text += "2";
        }

        private void btnNum3_Click(object sender, EventArgs e)
        {
            //botón numero 3
            txtBoxScreen.Text += "3";
        }

        private void btnNum4_Click(object sender, EventArgs e)
        {
            //botón numero 4
            txtBoxScreen.Text += "4";
        }

        private void btnNum5_Click(object sender, EventArgs e)
        {
            //botón numero 5
            txtBoxScreen.Text += "5";
        }

        private void btnNum6_Click(object sender, EventArgs e)
        {
            //botón numero 6
            txtBoxScreen.Text += "6";
        }

        private void btnNum7_Click(object sender, EventArgs e)
        {
            //botón numero 7
            txtBoxScreen.Text += "7";
        }

        private void btnNum8_Click(object sender, EventArgs e)
        {
            //botón numero 8
            txtBoxScreen.Text += "8";
        }

        private void btnNum9_Click(object sender, EventArgs e)
        {
            //botón numero 9
            txtBoxScreen.Text += "9";
        }
        private void btnNum0_Click(object sender, EventArgs e)
        {
            //botón numero 0
            txtBoxScreen.Text += "0";
        }

        private void btnFloat_Click(object sender, EventArgs e)
        {
            //botón punto decimal
            txtBoxScreen.Text += ".";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            //botón Suma
            nuevaCalculadora.Numero1 = float.Parse(txtBoxScreen.Text , nuevaCultura);
            valor1 = txtBoxScreen.Text;
            operacion = "+";
            txtBoxScreen.Clear();
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            //botón Resta
            nuevaCalculadora.Numero1 = float.Parse(txtBoxScreen.Text, nuevaCultura);
            valor1 = txtBoxScreen.Text;
            operacion = "-";
            txtBoxScreen.Clear();
        }

        private void btnProd_Click(object sender, EventArgs e)
        {
            //botón Producto
            nuevaCalculadora.Numero1 = float.Parse(txtBoxScreen.Text, nuevaCultura);
            valor1 = txtBoxScreen.Text;
            operacion = "x";
            txtBoxScreen.Clear();
        }

        private void btnDiv_Click(object sender, EventArgs e)
        {
            //botón División
            nuevaCalculadora.Numero1 = float.Parse(txtBoxScreen.Text, nuevaCultura);
            valor1 = txtBoxScreen.Text;
            operacion = "/";
            txtBoxScreen.Clear();
        }
        private void btnClean_Click(object sender, EventArgs e)
        {
            //botón Borrar
            txtBoxScreen.Clear();
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            //botón Igual
            nuevaCalculadora.Numero2 = float.Parse(txtBoxScreen.Text, nuevaCultura);

                       
            //validar que las variables no esten vacias
            valor2 = txtBoxScreen.Text;
            if (valor1 != null && valor2 != null)
            {
                resultado =  nuevaCalculadora.CalcularOperacion(nuevaCalculadora.Numero1, nuevaCalculadora.Numero2, operacion);
                txtBoxScreen.Text = resultado.ToString(nuevaCultura);

                //control de la división en 0
                if (nuevaCalculadora.Numero2 == 0 && operacion == "/")
                {   
                    txtBoxScreen.Text = "No se puede dividir en cero";
                }

                Calculadora miCulaculadora = new Calculadora();
                miCulaculadora.Numero1 = nuevaCalculadora.Numero1;
                miCulaculadora.Numero2 = nuevaCalculadora.Numero2;
                miCulaculadora.OperacionRealizada = operacion;
                miCulaculadora.FechaHora = DateTime.Now;
                miCulaculadora.Ecuación =   miCulaculadora.Numero1.ToString() + 
                                            miCulaculadora.OperacionRealizada + 
                                            miCulaculadora.Numero2.ToString() + 
                                            "=" + txtBoxScreen.Text;

                //agrego objetos a la lista
                Historial.Add(miCulaculadora);

                //muestro objetos de la lista
                listBoxHistorial.Items.Add(miCulaculadora.FechaHora + "--->" + miCulaculadora.Ecuación);

            }
            else
            {
                txtBoxScreen.Text = "Ingrese numeros";
            }            
        }

        private void listBoxHistorial_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBoxHistorial_DoubleClick(object sender, EventArgs e)
        {
            int index = listBoxHistorial.SelectedIndex;
            listBoxHistorial.Items.Remove(listBoxHistorial.SelectedItem);
            Historial.RemoveAt(index);            
        }
    }
}
