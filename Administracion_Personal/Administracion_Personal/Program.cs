using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Administracion_Personal;

namespace Admimistracion_Personal
{
    class Program
    {
        static void Main(string[] args){
            List<Empleados> Personas = new List<Empleados>();
            
            //Fecha actual
            DateTime Hoy = DateTime.Now;
            String F_Act = Convert.ToString(Hoy);
            Console.WriteLine("Fecha de hoy: {0}", F_Act);

            //------------------------------AGREGAR EMPLEADOS 
            for (int i = 1; i <= 20; i++) {
                Console.WriteLine("------Datos del empleado {0}\n", i);
                Subir_lista(Personas);
                Console.WriteLine("\n");
            }
            Console.WriteLine("--Cantidad de empleados: {0}", Personas.Count);
            Console.WriteLine("--Total a pagar: ${0}", Personas.Sum(x => x.salario()));
            Menu(Personas, F_Act);

             Console.ReadKey();
        }
        enum Nombres_Hombres { Javier, Luis, Ramon, Carlos, Pablo, Santiago, Ricardo, Alejandro, Nahuel, Agustin };
        enum Nombres_Mujeres { Maria, Carolina, Rocio, Celeste, Patricia, Lourdes, Mirtha, Micaela, Antonela, Carmen };
        enum Apelllidos { Sosa, Luna, Diaz, Herrera, Martinez, Jerez, Nieva, Cardozo, Brito, Villa};
        enum Genero{Masculino, Femenino};
        enum Estado_Civil { Casado, Soltero, Casada, Soltera };


        //------------------------------AGREGAR EMPLEADOS
        static Empleados Agregar_Emp(){
            Empleados dat_emp = new Empleados();
            //int cant_Per = 20;
            Random aleatorio = new Random();

            //Genero
            dat_emp._Genero = Genero_Per();

            //Nombre segun el genero
            if ((dat_emp._Genero).Contains("Masculino") == true)
            {
                int Opcion_Nombre = aleatorio.Next(0, 9);
                Nombres_Hombres Nombre = (Nombres_Hombres)Opcion_Nombre;
                dat_emp.Nombre = Convert.ToString(Nombre);
                int Opcion_Civil = aleatorio.Next(0, 1);
                Estado_Civil Estado = (Estado_Civil)Opcion_Civil;
                dat_emp.Estado_Civil = Convert.ToString(Estado);
            }
            else
            {
                int Opcion_Nombre = aleatorio.Next(0, 9);
                Nombres_Mujeres Nombre = (Nombres_Mujeres)Opcion_Nombre;
                dat_emp.Nombre = Convert.ToString(Nombre);
                int Opcion_Civil = aleatorio.Next(2, 3);
                Estado_Civil Estado = (Estado_Civil)Opcion_Civil;
                dat_emp.Estado_Civil = Convert.ToString(Estado);
            }

            //Apellido
            int Opcion_Apellido = aleatorio.Next(0, 9);
            Apelllidos Ape = (Apelllidos)Opcion_Apellido;
            dat_emp.Apellido = Convert.ToString(Ape);

            //Fecha de Nacimiento
            DateTime fecha_nac = new DateTime(aleatorio.Next(1955, 2002), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            dat_emp.Fecha_Nac = fecha_nac;

            //Fecha de ingreso
            DateTime fecha_ing = new DateTime(aleatorio.Next(1980, 2019), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            while (fecha_nac > fecha_ing)
            {
                fecha_ing = new DateTime(aleatorio.Next(1980, 2019), aleatorio.Next(1, 12), aleatorio.Next(1, 29));
            }
            dat_emp.Fecha_Ingreso = fecha_ing;

            //Sueldo Basico
            dat_emp.Sueldo_Base = (float)aleatorio.Next(10000, 25000);

            //Cargo
            int opcion_cargo = aleatorio.Next(0, 4);
            Trabajo Cargo = (Trabajo)opcion_cargo;
            dat_emp.Cargo = Convert.ToString(Cargo);

            return dat_emp;
        }
        //--Veo el Genero
        static string Genero_Per(){
            Random aleatorio = new Random();
            int Opcion= aleatorio.Next(0,1);
            Genero Sexo= (Genero)Opcion;
            string Genero = Convert.ToString(Sexo);  
            return Genero;
        }
        //--Subo los datos a la lista
        static void Subir_lista(List<Empleados> Personas)
        {
            Empleados dat_emp = new Empleados();
            dat_emp = Agregar_Emp();
            dat_emp.Mostrar();
            Personas.Add(dat_emp);
        }



        //------------------------------BUSCAR EMPLEADOS
        static void Buscar_Emp(List<Empleados> Personas) {
            Console.WriteLine("--Escriba el nombre, apellido o nombre completo: ");
            string nom_bus = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_bus.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0] || !Personas.Exists(y => y.apellido == partes_nom[1])))
            {
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_bus = Convert.ToString(Console.ReadLine());
                partes_nom = nom_bus.Split(' ');
            }
            Console.WriteLine(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Busco el empleado
        }


        //------------------------------ELIMINAR EMPLEADOS
        static void Eliminar_Emp(List<Empleados> Personas){
            Console.WriteLine("--Escriba el nombre completo: ");
            string nom_elim = Convert.ToString(Console.ReadLine());
            String[] partes_nom = nom_elim.Split(' ');
            //Me fijo que el empleado exista
            while (!Personas.Exists(x => x.nombre == partes_nom[0]) || !Personas.Exists(y => y.apellido == partes_nom[1])){
                Console.WriteLine("--No exite el empleado\nIngrese otro nombre\n--Escriba el nombre completo: ");
                nom_elim = Convert.ToString(Console.ReadLine());
                partes_nom = nom_elim.Split(' ');
            }
            Personas.Remove(Personas.Where(x => x.nombre == partes_nom[0]).FirstOrDefault()); //Elimino el empleado
        }

        //Menu
        static void Menu(List<Empleados> Personas, string F_Act)
        {
            char continuar = 's';

            do{
                //------------------------------MOSTRAR EMPLEADOS
                Console.WriteLine("\n\nElija una de estas opciones: ");
                Console.WriteLine("0) Buscar Empleado");
                Console.WriteLine("1) Agregar Empleado");
                Console.WriteLine("2) Eliminar Empleado");
                Console.WriteLine("3) Salir");
                Console.WriteLine("Ingrese aqui: ");
                int opcion= Convert.ToInt32(Console.ReadLine());

                while (opcion > 3) {
                    Console.WriteLine("--Opcion Incorrecta/Por Favor eliga una opcion valida");
                    Console.WriteLine("\n\nElija una de estas opciones: ");
                    Console.WriteLine("0) Buscar Empleado");
                    Console.WriteLine("1) Agregar Empleado");
                    Console.WriteLine("2) Eliminar Empleado");
                    Console.WriteLine("3) Salir");
                    Console.WriteLine("Ingrese aqui: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                }

                switch(opcion){
                    case 0:
                        //------------------------------BUSCAR EMPLEADOS
                        Buscar_Emp(Personas);
                        break;
                    case 1:
                        //------------------------------AGREGAR EMPLEADOS
                        Subir_lista(Personas);
                        break;
                    case 2:
                        //------------------------------ELIMINAR EMPLEADOS
                        Eliminar_Emp(Personas);
                        break;
                    case 3:
                        Environment.Exit(1);
                        break;
                }
                Console.WriteLine("Desea continuar? (S/N): ");
                continuar = Convert.ToChar(Console.ReadLine());
                while (continuar != 's' && continuar != 'S' && continuar != 'n' && continuar != 'N') {
                    Console.WriteLine("--Opcion Incorrecta/Por Favor eliga una opcion valida\nDesea continuar? (S/N): ");
                    continuar = Convert.ToChar(Console.ReadLine());
                }
            }while(continuar == 's' || continuar == 'S');
        }
        
    }
}
