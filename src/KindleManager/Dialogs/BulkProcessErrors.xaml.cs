﻿using ReactiveUI.Fody.Helpers;
using System;

namespace KindleManager.Dialogs
{
    /// <summary>
    /// Interaction logic for Error.xaml
    /// </summary>
    public partial class BulkProcessErrors : DialogBase
    {
        [Reactive]
        public GridRow[] Errors { get; set; }

        public BulkProcessErrors(string message, Exception[] errors)
        {
            Errors = new GridRow[errors.Length];

            for (int i = 0; i < errors.Length; i++)
            {
                Errors[i] = new GridRow((string)errors[i].Data["item"], errors[i].Message);
            }

            this.DataContext = this;

            InitializeComponent();
            Message.Text = message;
        }

        public class GridRow
        {
            public string Item { get; set; }
            public string Error { get; set; }
            public GridRow(string f, string e)
            {
                Item = f;
                Error = e;
            }
        }
    }
}
