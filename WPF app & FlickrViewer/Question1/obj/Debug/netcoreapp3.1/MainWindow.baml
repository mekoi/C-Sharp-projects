   M S B A M L   `   `   `  ����D  @Question1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Question1	Question1  5   	       Question1.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Question1     5   	     � Title$  Question1_App��5   	   $	��800��5	   	   $	��891��5
   	   .��5      � $	��784��6   .+�5   
   � $��0,0,10,0q�6    � ColumnDefinitions 5      �� 5      .+�5      � $��506,0,0,-10q�6   ���	#FFF3D5D5$
��Left=�5      $	��392��5      .+�5      �� $��Get Factorial Of:��6   $
��Left=�5      $��	17,69,0,0q�5      $	��Top=�5      $	��121��5      $��14(�5      $
��Bold"�5      �� 5      -   5         ��Name$ textBoxFactorialInput��5      $
��Left=�5      $��
143,69,0,0q�5       �� TextWrapping$
 Wrap=�5      $	��Top=�5      $��53��5       $��14(�5!      $��Normal"�5"      $��29��5#      �� 5$      -   5         ��Name$ buttonCalculateFactorial��5$      $��Calculate Factorial��5%      $��Center=�5&      $��	0,155,0,0q�5'      $	��Top=�5(      $	��150��5)      $��14(�5*      $
��Bold"�5+      $��50��5,      5-      �� 5.      -   5         ��Name$ labelFactorialResult��5.      $
��Left=�5/      $��121,226,0,0q�50      $	��Top=�51      $��Normal"�52      $	��193��53       J� RenderTransformOrigin$ 0.279,-0.222&�54      $��28��55      56      � 57      $��	0,0,380,0q�6   ���	#FFEDEDD3.+�59      &   System.Windows.Controls.DataGrid  -   5          Name$ datagridStockData��59      $��0,241,40,29q�5:      $��Right=�5;      $	��430��5<      �� 5=      -   5        $ 
buttonLoad��5=      $��Load Data From File��5>      $
��Left=�5?      $��	31,55,0,0q�5@      $	��Top=�5A      $��14(�5B      $
��Bold"�5C      $	��137��5D      $��36��5E      5F      �� 5G      $+��%Enter the company name to search for:��6   $
��Left=�5H      $��
208,25,0,0q�5I      $	��Top=�5J      $	��262��5K      $��14(�5L      $
��Bold"�5M      �� 5N      -   5        $ textBoxCompanyName��5N      $
��Left=�5O      $��
280,63,0,0q�5P      $
 Wrap=�5Q      $	��Top=�5R      $	��100��5S      $��14(�5T      $��Normal"�5U      $ -0.076,0.728&�5V      �� 5W      -   5        $ buttonSearch��5W      $��Search��5X      $
��Left=�5Y      $��280,102,0,0q�5Z      $	��Top=�5[      $��14(�5\      $
��Bold"�5]      $	��100��5^      $��31��5_      $ 
-0.17,0.42&�5`      5a      � 5b      -   5         �Name$ progressBar��5b      $
��Left=�5c      $��45��5d      $��
31,169,0,0q�5e      $	��Top=�5f      $	��430��5g      $��14(�5h      $
��Bold"�5i      �� 5j      -	   5        $ labelWarning��5j      $
��Left=�5k      $��280,138,0,0q�5l      $	��Top=�5m      $ 
0.59,0.216&�5n      $	��190��5o      5p      5r      5s      5t      