using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public static class Mesaages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string mantaincetime = "sistem bakımı zamanı";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError = "bu kategoride ürün limiti aşıldı ürün eklenemiyor.";
        public static string ProductNameAlreadyExists = "aynı isimde ürün bulunmakta";
        public static string AuthorizationDenied = "yetkiniz yok";
        public static string UserAlreadyExists = "zaten sistemde kayıtlısınız";
        public static string PasswordError = "şifre hatalı";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string UserRegistered = "kayıt başarılı";
        public static string SuccessfulLogin = "giriş başarılı";
        public static string AccessTokenCreated = "erişim oluşturuldu";
    }
}
