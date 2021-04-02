using System;
using System.Collections.Generic;
using Challenge2.Interfaces;

namespace Challenge2
{
	public class Repo : IRepositories<Media>
	{
        private List<Media> listTitle = new List<Media>();
		public void Upadate(int id, Media entity)
		{
			listTitle[id] = entity;
		}

		public void Delete(int id)
		{
			listTitle[id].ToDelete();
		}

		public void Enter(Media entity)
		{
			listTitle.Add(entity);
		}

		public List<Media> Lista()
		{
			return listTitle;
		}

		public int NextId()
		{
			return listTitle.Count;
		}

		public Media ReturnById(int id)
		{
			return listTitle[id];
		}
	}
}