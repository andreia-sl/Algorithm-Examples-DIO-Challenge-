﻿using System;

namespace Challenge2
{
    class Program
    {
        static Repo repositoryS = new Repo();
        static Repo repositoryM = new Repo();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ToList();
						break;
					case "2":
						ToAdd();
						break;
					case "3":
						ToUpdate();
						break;
					case "4":
						ToDelete();
						break;
					case "5":
						ToView();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Thanks for using our services.");
			Console.ReadLine();
        }

        private static void ToDelete()
		{
            Console.WriteLine("You want to delete movies (1) or series (2)");
            var option_list = Console.ReadLine().ToUpper(); 
            switch (option_list)
            {
                case "1":
                case "MOVIE":
                case "MOVIES":
                    Console.Write("Type the id of the title: ");
                    int indexMovie = int.Parse(Console.ReadLine());
                    repositoryM.Delete(indexMovie);
                    break;
                case "2":
                case "SERIE":
                case "SERIES":
                    Console.Write("Type the id of the title: ");
                    int indexSerie = int.Parse(Console.ReadLine());
                    repositoryS.Delete(indexSerie);
                    break;
                default:
                	throw new ArgumentOutOfRangeException();
            }
		}

        private static void ToView()
		{
            Console.WriteLine("You want to view movies (1) or series (2)");
            var option_list = Console.ReadLine().ToUpper(); 
            switch (option_list)
            {
                case "1":
                case "MOVIE":
                case "MOVIES":
                    Console.Write("Type the id of the title: ");
                    int indexMovie = int.Parse(Console.ReadLine());
                    var movie_title = repositoryM.ReturnById(indexMovie);
                    Console.WriteLine(movie_title);
                    break;
                case "2":
                case "SERIE":
                case "SERIES":
                    Console.Write("Type the id of the title: ");
                    int indexSerie = int.Parse(Console.ReadLine());
                    var serie_title = repositoryS.ReturnById(indexSerie);
                    Console.WriteLine(serie_title);
                    break;
                default:
                	throw new ArgumentOutOfRangeException();
            }
		}

        private static void ToUpdate()
		{
            Console.Write("Type the id of the title: ");
			int indexMedia = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genres)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genres), i));
			}
			Console.Write("Enter the genre (among the given options): ");
			int inGenres = int.Parse(Console.ReadLine());

            Console.Write("Enter the type movie (1) or serie (2) of the Title: ");
			string inType = Console.ReadLine().ToUpper();

			Console.Write("Enter the Title: ");
			string inTitle = Console.ReadLine();

			Console.Write("Enter the Start Year: ");
			int inYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the Description: ");
			string inDescription = Console.ReadLine();

			Media updateMedia = new Media(id: indexMedia,
										genres: (Genres)inGenres,
                                        type: inType,
										title: inTitle,
										year: inYear,
										description: inDescription);

            switch (inType)
            {
                case "1":
                case "MOVIE":
                case "MOVIES":
                    repositoryM.Upadate(indexMedia, updateMedia);
                    break;
                case "2":
                case "SERIE":
                case "SERIES":
                    repositoryS.Upadate(indexMedia, updateMedia);
                    break;
                default:
                	throw new ArgumentOutOfRangeException("Input movie or serie type!");
            }
		}
        private static void ToList()
		{
            Console.WriteLine("You want to list movies (1) or series (2)");
            var option_list = Console.ReadLine().ToUpper(); 
            switch (option_list)
            {
                case "1":
                case "MOVIE":
                case "MOVIES":
                    var listaM = repositoryM.Lista();
                    if (listaM.Count == 0)
                    {
                        Console.WriteLine("No title found.");
                        return;
                    }

                    foreach (var movie in listaM)
                    {
                        var deleted = movie.returnDeleted();
                        
                        Console.WriteLine("#ID {0}: - {1} {2}", movie.returnId(), movie.returnTitle(), (deleted ? "*Deleted*" : ""));
                    }
                    break;
                case "2":
                case "SERIE":
                case "SERIES":
                    var listaS = repositoryS.Lista();
                    if (listaS.Count == 0)
                    {
                        Console.WriteLine("No title found.");
                        return;
                    }

                    foreach (var serie in listaS)
                    {
                        var deleted = serie.returnDeleted();
                        
                        Console.WriteLine("#ID {0}: - {1} {2}", serie.returnId(), serie.returnTitle(), (deleted ? "*Deleted*" : ""));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Input movie or serie type!");
            }
			Console.WriteLine("List titles.");
		}

        private static void ToAdd()
		{
            Console.WriteLine("Enter new title");

			foreach (int i in Enum.GetValues(typeof(Genres)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genres), i));
			}
			Console.Write("Enter the genre (among the given options): ");
			int inGenres = int.Parse(Console.ReadLine());

            Console.Write("Enter the type movie (1) or serie (2) of the Title: ");
			string inType = Console.ReadLine();

			Console.Write("Enter the Title: ");
			string inTitle = Console.ReadLine();

			Console.Write("Enter the Start Year: ");
			int inYear = int.Parse(Console.ReadLine());

			Console.Write("Enter the description: ");
			string inDescription = Console.ReadLine();
            
            switch (inType)
            {
                case "1":
                case "MOVIE":
                case "MOVIES":
                    Media newMovie = new Media(id: repositoryM.NextId(),
										genres: (Genres)inGenres,
                                        type: inType,
										title: inTitle,
										year: inYear,
										description: inDescription);
                    repositoryM.Enter(newMovie);
                    break;
                case "2":
                case "SERIE":
                case "SERIES":
                    Media newSerie = new Media(id: repositoryS.NextId(),
										genres: (Genres)inGenres,
                                        type: inType,
										title: inTitle,
										year: inYear,
										description: inDescription);
                    repositoryS.Enter(newSerie);
                    break;
                default:
                	throw new ArgumentOutOfRangeException();
            }
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("Movies and Series for you to look!");
			Console.WriteLine("Enter your option: ");

			Console.WriteLine("1- List");
			Console.WriteLine("2- Enter new title");
			Console.WriteLine("3- Update title");
			Console.WriteLine("4- Delete title");
			Console.WriteLine("5- View title");
			Console.WriteLine("C- Clean Screen");
			Console.WriteLine("X- Exit");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}