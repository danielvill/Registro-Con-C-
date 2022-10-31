using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Registro_PRUEBA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        RegistrobienesEntities2 entities = new RegistrobienesEntities2();   
        
        public void conexion()
        {
            SqlConnection conectar = new SqlConnection(" server=DESKTOP-D9SLKOC\\SQLEXPRESS ; database=Registrobienes ; integrated security = true");
            conectar.Open();
            


         }
        public void actualizar()
        {
            SqlConnection conectar = new SqlConnection(" server=DESKTOP-D9SLKOC\\SQLEXPRESS ; database=Registrobienes ; integrated security = true");
            conectar.Open();

            SqlCommand coa = new SqlCommand("Select * from Registro", conectar);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = coa;
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            dataGridView1.DataSource = tabla;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (RegistrobienesEntities2 entities2 = new RegistrobienesEntities2())
            {
                Registro re = new Registro();
                re.id_reg = Convert.ToInt16(textBox1.Text);
                re.nombre = textBox2.Text;
                re.precio = Convert.ToDouble(textBox3.Text);
                re.direccion = textBox4.Text;
                entities2.Registro.Add(re);
                entities2.SaveChanges();

                MessageBox.Show("Enviado a la base de datos");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                actualizar();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conectar = new SqlConnection(" server=DESKTOP-D9SLKOC\\SQLEXPRESS ; database=Registrobienes ; integrated security = true");
            
            string query = "update Registro set nombre = @nombre,precio = @precio, direccion = @direccion   where id_reg = @id_reg";
            conectar.Open();
            SqlCommand coma =new SqlCommand(query, conectar);
            coma.Parameters.AddWithValue("@nombre", textBox2.Text);
            coma.Parameters.AddWithValue("@precio", textBox3.Text);
            coma.Parameters.AddWithValue("@direccion ", textBox4.Text);
            coma.Parameters.AddWithValue("@id_reg ", textBox1.Text);
            coma.ExecuteNonQuery();
            
            conectar.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            actualizar();


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'registrobienesDataSet.Registro' Puede moverla o quitarla según sea necesario.
            this.registroTableAdapter.Fill(this.registrobienesDataSet.Registro);

            conexion();
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int flag = 0;
            SqlConnection conectar = new SqlConnection(" server=DESKTOP-D9SLKOC\\SQLEXPRESS ; database=Registrobienes ; integrated security = true");
            conectar.Open();
            string cadena = "Delete from Registro where nombre = '" +textBox2.Text +"'";
            SqlCommand comad = new SqlCommand(cadena,conectar);
            
            flag = comad.ExecuteNonQuery();
            if(flag == 1)
            {
                MessageBox.Show("se realizo");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            else
            {
                MessageBox.Show("No se elimino");
            }
            actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }
    }
}
