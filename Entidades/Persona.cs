using System.Text;

namespace Entidades
{
    public abstract class Persona
    {
        private string apellido;
        private int dni; 
        private int edad;
        private string nombre;

        public Persona(string nombre,string apellido, int edad, int dni)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.edad = edad;
            this.dni = dni;
        }

        public string Apellido { get => this.apellido; }
        public int Dni { get => this.dni; }
        public int Edad { get => this.edad; }
        public string Nombre { get => this.nombre; }

        public virtual string Mostrar()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Nombre: {this.nombre}\n" +
                      $"Apellido: {this.apellido}\n" +
                      $"Edad: {this.edad}\n" +
                      $"Dni: {this.dni}\n");

            return sb.ToString();
        }

        public abstract bool ValidarAptitud();
    }
}