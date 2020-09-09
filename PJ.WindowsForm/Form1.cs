using PJ.BusinessEntity;
using PJ.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PJ.WindowsForm
{
    public partial class Form1 : Form
    {
        FuncionesLogicas misFuncioens = new FuncionesLogicas();
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            bool conectarDb = misFuncioens.ValidaConexionSQL();

            if (conectarDb==true)
            {
                MessageBox.Show("Conexion Exitoa","Tes .NET");

            }

            else
            {
                MessageBox.Show("Error con Conexion a SQL ", "Tes .NET");
            }   


        }

        private void LblNombre_Click(object sender, EventArgs e)
        {

        }

        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            Customer ObjCustomer = new Customer();
            string Result = "Error";

            ObjCustomer.CustomerName = txtNombre.Text;
            ObjCustomer.Contact = txtContacto.Text;
            ObjCustomer.Email = txtEmail.Text;
            ObjCustomer.Rif = txtRif.Text;


            Result = misFuncioens.CreateCustomer(ObjCustomer);

            if (Result == "Exitoso")
            {
                MessageBox.Show("Registro Exitoso de " + ObjCustomer.CustomerName);

            }

            else
            {
                MessageBox.Show("Registro Existente " + ObjCustomer.CustomerName);
            }

        }
    }
}
