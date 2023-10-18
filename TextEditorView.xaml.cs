using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Net.Mime;
using Microsoft.Win32;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for TextEditorView.xaml
    /// </summary>
    public partial class TextEditorView : UserControl
    {
        TextProps _textProps = new TextProps();
        public List<FontFamily> fonts = new ();

        public TextEditorView()
        {
            InitializeComponent();
            DataContext = _textProps;
            fonts = _textProps.FontFamilies;
        }
        
            private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Create);
                TextRange range = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);
                range.Save(fileStream, DataFormats.Rtf);
            }
        }

        private void Size14_OnSelected(object sender, RoutedEventArgs e)
        {
            if (size18.IsSelected == true)
            {
                TextField.FontSize = 14;
            }
        }

        private void Size16_OnSelected(object sender, RoutedEventArgs e)
        {
            if (size16.IsSelected == true)
            {
                TextField.FontSize = 16;
            };
        }

        private void Size18_OnSelected(object sender, RoutedEventArgs e)
        {
            if (size18.IsSelected == true)
            {
                TextField.FontSize = 18;
            }
        }

        private void Size46_OnSelected(object sender, RoutedEventArgs e)
        {
            if (size46.IsSelected == true)
            {
                TextField.FontSize = 46;
            }
        }

        private void ToggleBoldBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ToggleBoldBtn.IsChecked == true)
            {
                TextField.FontWeight = FontWeights.ExtraBlack;
            }
            else
            {
                TextField.FontWeight = FontWeights.Normal;
            }
        }

        private void ToggleItalicBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (ToggleItalicBtn.IsChecked == true)
            {
                TextField.FontStyle = FontStyles.Italic;
            }
            else
            {
                TextField.FontStyle = FontStyles.Normal;
            }
        }

        private void ToggleUnderlineBtn_OnClick(object sender, RoutedEventArgs e)
        {
            //TextRange selectedText = TextField.Selection;

            //if (ToggleUnderlineBtn.IsChecked == true)
            //{
            //    var underline = new TextDecorationCollection();
            //    underline.Add(TextDecorations.Underline);
            //    selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, underline);
                
            //}
            //else
            //{
            //    selectedText.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            //}


            TextRange text = new TextRange(TextField.Document.ContentStart, TextField.Document.ContentEnd);

            if (ToggleUnderlineBtn.IsChecked == true)
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
            else
            {
                text.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
            }
        }

        private void ConsolasFont_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontFamily = new FontFamily("Consolas");
        }

        private void ComicSansFont_OnSelected(object sender, RoutedEventArgs e)
        {
            TextField.FontFamily = new FontFamily("Comic Sans MS");
        }
    }
}
