using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class DirectorTecnico : Persona
    {
        private int añosExperiencia;

        public int AñosExperiencia { get => this.añosExperiencia; }

        public DirectorTecnico(string nombre, string apellido, int edad, int dni, int añosExperiencia)
            : base(nombre, apellido, edad, dni)
        {
            this.añosExperiencia = añosExperiencia;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder(base.Mostrar());
            sb.Append($"Años de experiencia: {this.añosExperiencia}\n\n");
            return sb.ToString();
        }

        public override bool ValidarAptitud()
        {
            return this.Edad < 65 && this.añosExperiencia >= 2;
        }
    }
}
