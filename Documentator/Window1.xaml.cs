/*
 * Сделано в SharpDevelop.
 * Пользователь: suvoroda
 * Дата: 09/07/2015
 * Время: 09:50
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Microsoft.Win32;

namespace Documentator
{
	/// <summary>
	/// Interaction logic for Window1.xaml
	/// </summary>
	public partial class Window1 : Window
	{
		public Window1()
		{
			InitializeComponent();
			sfd = new SaveFileDialog();
			ofd = new OpenFileDialog();
			etypes = new List<ElementTypes>();
			ArrayTypeElements = new List<TypeElements>();
		}
		ParsTypeElement pte;
		SaveFileDialog sfd;
		OpenFileDialog ofd;
		DocumentationXml Dx;
		OpenDocumentationFromXml _doc;
		List<ElementTypes> etypes;
		List<TypeElements> ArrayTypeElements;
		string FileShablon;
		string FileDocumentation;
		/// <summary>
		/// Выход
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Exit_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
		/// <summary>
		/// Заполнить ComboBoxs на основе xml файла
		/// </summary>
		void InElementBox()
		{			
			InAllTypeElement();
			InAllElement();
		}	
		/// <summary>
		/// Заоплнить ComboBox типами
		/// </summary>
		void InAllTypeElement()
		{
			TypeElementComboBox.Items.Clear();
			foreach(string et in pte.PathsList)
			{
				TypeElementComboBox.Items.Add(et);
				ArrayTypeElements.Add(new TypeElements(et));
			}
		}
		/// <summary>
		/// Заполнить ComboBox элементами
		/// </summary>
		void InAllElement()
		{			
			ShablonComboBox.Items.Clear();
			if(TypeElementComboBox.SelectedIndex != -1)
				if(TypeElementComboBox.SelectedValue.ToString() != String.Empty)
				{
					foreach(ElementTypes et in pte.ElementTypesList)
						if (et.Path == TypeElementComboBox.SelectedValue.ToString())
							ShablonComboBox.Items.Add(et.Name);
				}
		}
		/// <summary>
		/// Перезаполнить ComboBox элементов на основе выбраного типа
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void TypeElementComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{			
			InAllElement();
		}
		/// <summary>
		/// Добавить элемент в документацию
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void AddElement_Click(object sender, RoutedEventArgs e)
		{
			MainText.AppendText(String.Format("Тип Элемента : {0} \r\n",TypeElementComboBox.SelectedValue));
			MainText.AppendText(String.Format("Элемент : {0} \r\n",ShablonComboBox.SelectedValue));
			MainText.AppendText(String.Format("Имя : {0} \r\n",NameElement.Text));
			MainText.AppendText(String.Format("Описание : {0} \r\n",Note.Text));
			MainText.AppendText(String.Format("Событие : {0} \r\n",EventText.Text));
			MainText.AppendText(String.Format("Сцена : {0} \r\n",SceneNameText.Text));
			etypes.Add(new ElementTypes(NameElement.Text,TypeElementComboBox.SelectedValue.ToString(),ShablonComboBox.SelectedValue.ToString(),Note.Text, EventText.Text, SceneNameText.Text));
		}
		/// <summary>
		/// Сохранить/получить XML файл
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Save_Click(object sender, RoutedEventArgs e)
		{			
			if(sfd.ShowDialog() != false)
			{
				Dx = new DocumentationXml(sfd.FileName/*PathToXml*/,etypes, ArrayTypeElements);
			}
		}
		/// <summary>
		/// Открыть xml файл типов/элементов
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void Open_Click(object sender, RoutedEventArgs e)
		{
			if(ofd.ShowDialog() != false)
			{
				InicShablon();
			}
		}
		/// <summary>
		/// Инициализировать шаблон
		/// </summary>
		void InicShablon()
		{
			FileShablon = ofd.FileName;			
			pte = new ParsTypeElement(FileShablon);
			pte.ReadNodes();			
			InElementBox();
		}
		/// <summary>
		/// Событие открытия файла
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void OpenDocumentation_Click(object sender, RoutedEventArgs e)
		{
			if(ofd.ShowDialog() != false)
				InicDataFromDocumentation();
		}
		/// <summary>
		/// Открывает xml и выводит информацию
		/// </summary>
		void InicDataFromDocumentation()
		{			
			FileDocumentation = ofd.FileName;
			_doc = new OpenDocumentationFromXml(FileDocumentation);
			MainText.AppendText(_doc.GetAllNodes());
		}
	}
}