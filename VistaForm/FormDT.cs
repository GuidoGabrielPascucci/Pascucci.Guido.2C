using Entidades;

namespace VistaForm
{
    public partial class FormDT : Form
    {
        private DirectorTecnico? dt;
        
        public FormDT()
        {
            InitializeComponent();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            string nombre = this.txtNombre.Text;
            string apellido = this.txtApellido.Text;
            int edad = (int)this.numEdad.Value;
            int dni = (int)this.numDni.Value;
            int añosExperiencia = (int)this.numExperiencia.Value;
            this.dt = new DirectorTecnico(nombre, apellido, edad, dni, añosExperiencia);
            MessageBox.Show("Se ha creado el DT!");
        }

        private void btnValidar_Click(object sender, EventArgs e)
        {
            if (this.dt is null)
                MessageBox.Show("Aún no se ha creado el DT del formulario");
            else if (!this.dt.ValidarAptitud())
                MessageBox.Show("El DT no es apto.");
            else
                MessageBox.Show("El DT es apto.");
        }

        private void FormDT_Load(object sender, EventArgs e)
        {
        }
    }
}