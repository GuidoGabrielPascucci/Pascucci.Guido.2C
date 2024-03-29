﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Jugador : Persona
    {
        private float altura;
        private float peso;
        private Posicion posicion;

        public float Altura { get => this.altura; }
        public float Peso { get => this.peso; }
        public Posicion Posicion { get => this.posicion; }

        public Jugador(string nombre, string apellido, int edad, int dni, float peso, float altura, Posicion posicion)
            : base(nombre, apellido, edad, dni)
        {
            this.altura = altura;
            this.peso = peso;
            this.posicion = posicion;
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder(base.Mostrar());
            sb.Append($"Altura: {this.altura}\n" +
                      $"Peso: {this.peso}\n" +
                      $"Posición: {this.posicion}\n\n");
            return sb.ToString();
        }

        public override bool ValidarAptitud()
        {
            return this.Edad < 40 && this.ValidarEstadoFisico();
        }

        public bool ValidarEstadoFisico()
        {
            double imc = this.peso / Math.Pow(this.altura, 2);
            return imc >= 18.5 && imc <= 25;
        }
    }
}