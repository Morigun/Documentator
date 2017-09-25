/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/07/2015
 * Время: 10:13
 */
using System;

namespace Documentator
{
	/// <summary>
	/// Description of ElementTypes.
	/// </summary>
	public class ElementTypes
	{
		public ElementTypes()
		{
		}
		/// <summary>
		/// Конструктор класса ElementTypes
		/// </summary>
		/// <param name="Name">Имя</param>
		/// <param name="Path">Путь</param>
		public ElementTypes(string _name, string _path)
		{
			this.Name = _name;
			this.Path = _path;
		}	
		/// <summary>
		/// Конструктор класса ElementTypes
		/// </summary>
		/// <param name="Name">Имя</param>
		/// <param name="TypEl">Тип элемента</param>
		/// <param name="ElementVid">Вид элемента</param>
		/// <param name="Note">Описание элемента</param>
		public ElementTypes(string _name, string _typEl, string _el, string _note, string _event, string _nameScene)
		{
			this.Name = _name;
			this.El = _el;
			this.Note = _note;
			this.TypeEl = new TypeElements(_typEl);
			this.EventText = _event;
			this.NameScene = _nameScene;
		}		
		public string Name{get;set;}
		public string Path{get;set;}
		public string Note{get;set;}
		public TypeElements TypeEl{get;set;}
		public string El{get;set;}
		public string EventText{get;set;}
		public string NameScene{get;set;}
	}
	/// <summary>
	/// Класс Типы элементов, для сбора всех типов элементов
	/// </summary>
	public class TypeElements
	{
		/// <summary>
		/// Конструктор Типов элементов принимает наименование элемента
		/// </summary>
		/// <param name="Name">Имя элемента</param>
		public TypeElements(string _name)
		{
			this.Name = _name;
		}
		public string Name;
	}
}
