using System.Net.Sockets;

namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private NetworkStream salida; 
        private BinaryWriter escritor; 
        private BinaryReader lector; 
        private Thread lecturaThread; 
        private string mensaje = "";

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void ClienteChatForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        //lazagol
        private delegate void DisplayDelegate(string messaje);

        private void MostrarMensaje(string menssaje)
        {
            if (mostrarTextbox.InvokeRequired)
            {
                Invoke(new DisplayDelegate(MostrarMensaje), new object[] { mensaje });

            }
            else

                mostrarTextbox.Text += mensaje;
        }

        private delegate void DisableInputDelegate(bool value);

        private void DeshabilitarSalida(bool valor)
        {
            if (entradaTextbox.InvokeRequired)
            {
                Invoke(new DisableInputDelegate(DeshabilitarSalida), new object[] { valor });

            }
            else
                entradaTextbox.ReadOnly = valor;
        }

        private void entradaTextbox_TextChanged(object sender, EventArgs e)
        {

        }
        private void entradaTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && entradaTextbox.ReadOnly == false)
                {
                    escritor.Write("CLIENTE>>>" + entradaTextbox.Text);
                    mostrarTextbox.Text += "\r\nCLIENTE>>>" + entradaTextbox.Text;
                    entradaTextbox.Clear();
                }
            }
            catch (SocketException)
            {
                mostrarTextbox.Text += "\n Error al escribir el objeto";
            }
        }
        //comenzar de aca mauro
        public void EjecutarCliente()
        {
            TcpClient cliente;
             
            
            try
            {
                MostrarMensaje("Tratando de conectar\r\n");
                cliente = new TcpClient();
                cliente.Connect(this.IPtextbox.Text, 50000);

                salida = cliente.GetStream();

                escritor = new BinaryWriter(salida);
                lector = new BinaryReader(salida);

                MostrarMensaje("\r\nSe recibieron flujos de E/S\r\n");
                DeshabilitarSalida(false);

                do
                {
                    try
                    {
                        
                        mensaje = lector.ReadString();
                        MostrarMensaje("\r\n" + mensaje);

                    }
                    catch (Exception)
                    {
                        System.Environment.Exit(System.Environment.ExitCode);
                    }
                } while (mensaje != "SERVIDOR>>> TERMINAR ");

                escritor.Close();
                lector.Close();
                salida.Close();
                cliente.Close();
                Application.Exit();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error en la conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(System.Environment.ExitCode);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lecturaThread = new Thread(new ThreadStart(EjecutarCliente));
            lecturaThread.Start();
        }
    }
}
