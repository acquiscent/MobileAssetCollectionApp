   M S B A M L   `   `   `  ����  MobileAssetCollectionApp)    #MobileAssetCollectionApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5        $��
mainwindow��5   M     � Title$  
MainWindow��6	   $	��400��6   $	��800��6)    � WindowState$ 	Maximized=�65   .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6   �� 5	      $��50 �6   .+�5   
   � $��1��6   .+�5      &   System.Windows.Controls.DataGrid     SelectionMode$ Single=�6<      AutoGenerateColumns .     CanUserResizeRows .     CanUserDeleteRows .    HeadersVisibility$ Column=�6�   ��6   �� *AssetSetList+ �� SelectedItem 6S   �� *CurrentAssetSetItem+	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 20* 6)      Header$ Asset Letter/Mobile Type��65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 5      `� 5       �� StringFormat$ {0}.{1}��6+   .1�5   "   ��  �� Path$ AssetLetter�6*   �� 5   "   $ 
DeviceType�6*   5      5        5      $	
 20* 6*   $ 
Dimensions��66    5      `� 5      $ {0}x{1}��6+   .1�5   "   �� $ ImageWidthPixels�6*   �� 5   "   $ ImageHeightPixels�6*   5      5      4  .System.Windows.Controls.DataGridTemplateColumn  5      $	
 20* 6.   $ Attach .PNG|.jpg��6:      CellTemplate 5      �� 5       .R�5!   "   � $��Stretch=�6'    � ColumnDefinitions 5"   &   �� 5#   *   $	��80* �6;   �� 5$   *   $	��20* �6;   .+�5&   &   �� $��0��60   $
��Wrap=�6d   ��6@   �� *Attach1FilesString+6d   �� 5'   &   $��1��6-   $��Center=�6=   $��Center=�6Z   $��Browse��6u   ��6�   ��  �� ElementName$ 
mainwindow��$&  DataContext.Attach1BrowseCommand�5(   #   5)      5+        5,      $	
 20* 6.   $ Attach .svg|.pi|.ai��6:    5-      �� 5.      .R�5/   "   � $��Stretch=�6'    50   &   �� 51   *   $	��80* �6;   �� 52   *   $	��20* �6;   .+�54   &   �� $��0��60   $
��Wrap=�6d   ��6@   �� *Attach2FilesString+6d   �� 55   &   $��1��6-   $��Center=�6=   $��Center=�6Z   $��Browse��6u   ��6�   �� $ 
mainwindow��$&  DataContext.Attach2BrowseCommand�56   #   57      59        5:      $	
 10* 6*   $ 
Asset Type��6T    66   �� *	AssetType+6T     5;      $	
 10* 6.    5<      �� 5=      .R�5>   "   �� $��Click to Preview��6)   $	��100��6�   ��6D   �� $ 
mainwindow��$  DataContext.PreviewCommand�6�   5?      5A      5C      5D      � 5E   
   $��2��6    5F      �� 5G      $	��80* �6#   �� 5H      $	��20* �6#   .+�5J      �� $��1��6   $��
Zip Images��6%   ��6;   �� $ 
mainwindow��$ DataContext.ZipCommand�5K      5L      5M      