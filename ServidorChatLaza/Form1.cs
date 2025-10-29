using System.Net;
using System.Net.Sockets;

namespace ServidorChatLaza
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string miIP = ObtenerIPLocal();
            Console.WriteLine("Mi IP local es: " + miIP);
            IPtextbox.Text = miIP;
        }
        private Socket conexion;
        private Thread lecturaThread; 
        private NetworkStream socketStream; 
        private BinaryWriter escritor;
        private BinaryReader lector;
        string miIP = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            miIP = ObtenerIPLocal();
            IPtextbox.Text = miIP;
            lecturaThread = new Thread(new ThreadStart(EjecutarServidor));
            lecturaThread.Start();
        }
        private void ServidorChatForm_FormClosing(object sander,
            FormClosingEventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        
        
        private delegate void DisplayDelegate(string mensaje);
        private void MostrarMensaje(string mensaje)
        {
            if (mostrarTextbox.InvokeRequired)
            {

                Invoke(new DisplayDelegate(MostrarMensaje),
                    new object[] { mensaje });
            }
            else
                mostrarTextbox.Text += mensaje;
        }


        
        private delegate void DisableInputDelegate(bool value);

        private void DeshabilitarEntrada(bool valor)
        
        {
            if (entradaTextbox.InvokeRequired)

            {
                
                

                Invoke(new DisableInputDelegate(DeshabilitarEntrada),

                   new object[] { valor });
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

                    escritor.Write("SERVIDOR>>> " + entradaTextbox.Text);
                    mostrarTextbox.Text += "\r\nSERVIDOR>>> " + entradaTextbox.Text;

                    
                    
                    if (entradaTextbox.Text == "TERMINAR")
                        conexion.Close();

                    entradaTextbox.Text = ""; 
                } 
            }
            catch (SocketException)
            {
                mostrarTextbox.Text += "\nError al escribir objeto";
            } 

        }
        public static string ObtenerIPLocal()
        {
            string ipLocal = "No se pudo obtener la IP";

            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var ip in host.AddressList)
                {
                    
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipLocal = ip.ToString();
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                ipLocal = $"Error: {ex.Message}";
            }

            return ipLocal;
        }

        public void EjecutarServidor()
        {
            TcpListener oyente;
            int contador = 1;

            
            
            try
            {

                
                
                IPAddress local = IPAddress.Parse(miIP);
                oyente = new TcpListener(local, 50000);
                
                oyente.Start();
                
                while (true)
                {
                    MostrarMensaje("Esperando una conexion\r\n");
                    
                    conexion = oyente.AcceptSocket();
                    

                    socketStream = new NetworkStream(conexion);
                    escritor = new BinaryWriter(socketStream);
                    lector = new BinaryReader(socketStream);

                    MostrarMensaje("conexion " + contador + "recibida.\r\n");



                    
                    escritor.Write("SERVIDOR>>> Conexion exitosa");

                    

                    DeshabilitarEntrada(false); 

                    string laRespuesta = "";

                    
                    do

                    {
                        try
                        {
                            
                            laRespuesta = lector.ReadString();
                            
                            
                            MostrarMensaje(laRespuesta);
                        } 

                        

                        catch (Exception)

                        {

                            
                            break;
                        } 
                    } while (laRespuesta != "CLIENTE>>> TERMINAR" &&
                    conexion.Connected);

                    MostrarMensaje("\r\nE1 usuario termino la conexion\r\n");

                    
                    escritor.Close();
                    lector.Close();
                    socketStream.Close();
                    conexion.Close();


                    DeshabilitarEntrada(true); 
                    contador++;
                }
            }

            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }

    }
}
