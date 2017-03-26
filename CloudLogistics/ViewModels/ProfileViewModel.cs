﻿using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CloudLogistics.ViewModels
{
    public class ProfileViewModel
    {
        public ICommand TakePhotoCommand { get; private set; }

        public ICommand PickPhotoCommand { get; private set; }

        public ImageSource ImageSource { get; private set; }

        public ProfileViewModel(Page page)
        {
            TakePhotoCommand = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await page.DisplayAlert("Ошибка", "Нет доcтупной камеры", "Ок");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                {
                    return;
                }

                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSource)));
            });

            PickPhotoCommand = new Command(async () =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    await page.DisplayAlert("Ошибка", "Выбор фото не поддерживается", "Ок");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions());

                if (file == null)
                {
                    return;
                }

                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    file.Dispose();
                    return stream;
                });

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageSource)));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

