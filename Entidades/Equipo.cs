using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Equipo
    {
        private const int cantidadMaximaJugadores = 6;
        private DirectorTecnico? directorTecnico;
        private List<Jugador>? jugadores;
        private string? nombre;

        public DirectorTecnico DirectorTecnico
        {
            set
            {
                if (value.ValidarAptitud())
                    this.directorTecnico = value;
            }
        }
        public string? Nombre { get => this.nombre; }
        
        private Equipo()
        {
            this.jugadores = new List<Jugador>();
        }

        public Equipo(string nombre) : base()
        {
            this.nombre = nombre;
        }

        public static explicit operator string (Equipo e)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Nombre: {e.nombre}");
            
            if (e.directorTecnico is not null)
                sb.AppendLine($"\nDirector Técnico:\n" +
                              $"{e.directorTecnico.Mostrar()}");
            else
                sb.AppendLine($"Director Técnico: Sin DT asignado");

            sb.AppendLine("Jugadores");

            if (e.jugadores is not null)
            {
                foreach (Jugador jugador in e.jugadores)
                    sb.AppendLine(jugador.Mostrar() + "\n");
            }

            return sb.ToString();
        }

        public static bool operator !=(Equipo e, Jugador j)
        {
            return !(e == j);
        }

        public static bool operator ==(Equipo e, Jugador j)
        {
            if (e.jugadores is not null)
            {
                foreach (Jugador jugador in e.jugadores)
                {
                    if (j.Equals(jugador))
                        return true;
                }
            }

            return false;
        }

        public static Equipo operator +(Equipo e, Jugador j)
        {
            if (e.jugadores is not null)
            {
                if (e != j && e.jugadores.Count < Equipo.cantidadMaximaJugadores && j.ValidarAptitud())
                    e.jugadores.Add(j);
            }

            return e;
        }

        public static bool ValidarEquipo(Equipo e)
        {
            bool hayArquero = false;
            bool hayDefensor = false;
            bool hayCentral = false;
            bool hayDelantero = false;

            if (e.jugadores is not null)
            {
                int cantidadArqueros = 0;

                foreach (Jugador jugador in e.jugadores)
                {
                    if (jugador.Posicion == Posicion.Arquero)
                        cantidadArqueros++;
                }

                if (cantidadArqueros > 1)
                    return false;
                else
                {
                    hayArquero = e.jugadores.Exists(jugador => jugador.Posicion == Posicion.Arquero);
                    hayDefensor = e.jugadores.Exists(jugador => jugador.Posicion == Posicion.Defensor);
                    hayCentral = e.jugadores.Exists(jugador => jugador.Posicion == Posicion.Central);
                    hayDelantero = e.jugadores.Exists(jugador => jugador.Posicion == Posicion.Delantero);

                    if (hayArquero && hayDefensor && hayCentral && hayDelantero)
                    {
                        if (e.directorTecnico is not null && e.jugadores.Count == Equipo.cantidadMaximaJugadores)
                            return true;
                    }
                }
            }

            return false;
        }
    }
}
