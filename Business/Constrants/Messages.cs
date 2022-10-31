using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constrants
{
    public class Messages
    {
        public static string CarAdded = "Araba Eklendi!";
        public static string CarAddError = "Araba Eklenirken Bir Sorun Oluştu!";
        public static string CarDeleted = "Araba Kaldırıldı!";
        public static string CarDeleteError = "Araba Kaldırılırken Bir Sorun Oluştu!";
        public static string CarUpdated = "Araba Güncellendi!";
        public static string CarUpdateError = "Araba Güncellenirken Bir Sorun Oluştu!";
        public static string ColorAdded = "Renk Eklendi!";
        public static string ColorAddError = "Renk Eklenirken Bir Sorun Oluştu!";
        public static string ColorUpdated = "Renk Güncellendi!";
        public static string ColorUpdateError = "Renk Güncellenirken Bir Sorun Oluştu!";
        public static string ColorDeleted = "Renk Kaldırıldı!";
        public static string ColorDeleteError = "Renk Kaldırılırken Bir Sorun Oluştu!";
        public static string BrandAdded = "Marka Eklendi!";
        public static string BrandAddError = "Marka Eklenirken Bir Sorun Oluştu!";
        public static string BrandUpdated = "Marka Güncellendi!";
        public static string BrandUpdateError = "Marka Güncellenirken Bir Sorun Oluştu!";
        public static string BrandDeleted = "Marka Kaldırıldı!";
        public static string BrandDeleteError = "Marka Kaldırılırken Bir Sorun Oluştu!";
        public static string MaintenanceTime = "Bakım Zamanı!";
        public static string UserAdded = "Kullanıcı Eklendi!";
        public static string UserAddError = "Kullanıcı Eklenirken Bir Sorun Oluştu!";
        public static string UserUpdated = "Kullanıcı Güncellendi!";
        public static string UserUpdateError = "Kullanıcı Güncellenirken Bir Sorun Oluştu!";
        public static string UserDeleted = "Kullanıcı Kaldırıldı!";
        public static string UserDeleteError = "Kullanıcı Kaldırılırken Bir Sorun Oluştu!";
        public static string CustomerAdded = "Müşteri Eklendi!";
        public static string CustomerAddError = "Müşteri Eklenirken Bir Sorun Oluştu!";
        public static string CustomerUpdated = "Müşteri Güncellendi!";
        public static string CustomerUpdateError = "Müşteri Güncellenirken Bir Sorun Oluştu!";
        public static string CustomerDeleted = "Müşteri Kaldırıldı!";
        public static string CustomerDeleteError = "Müşteri Kaldırılırken Bir Sorun Oluştu!";
        public static string RentalAdded = "Kiralama Eklendi!";
        public static string RentalAddError = "Kiralama Eklenirken Bir Sorun Oluştu!";
        public static string RentalUpdated = "Kiralama Güncellendi!";
        public static string RentalUpdateError = "Kiralama Güncellenirken Bir Sorun Oluştu!";
        public static string RentalDeleted = "Kiralama Kaldırıldı!";
        public static string RentalDeleteError = "Kiralama Kaldırılırken Bir Sorun Oluştu!";
        public static string CarImageAdded = "Araç Resmi Eklendi!";
        public static string CarImageDeleted = "Araç Resmi Silindi!";
        public static string CarImageUpdated = "Araç Resmi Güncellendi!";
        public static string AuthorizationDenied = "Yetkiniz yok!";
        public static string UserRegistered = "Kullanıcı kayıt oldu!";
        public static string PasswordError = "Parola hatası!";
        public static string SucessfulLogin = "Başarıyla giriş yapıldı!";
        public static string UserNotFound = "Kullanıcı bulunamadı!";
        public static string UserAlreadyExists = "Kullanıcı zaten bulunuyor!";
        public static string AccessTokenCreated = "AccessToken yaratıldı!";
        public static string RentalWasDelivered = "Kiralama teslim edildi!";
        public static string RentalsListed = "Kiralamalar listelendi!";
        public static string TheRentalListed = "Kiralama listelendi!";
        public static string CarIsInAlreadyRental = "Bu araç zaten kiralanmış!";
        public static string TheCustomerDoesNotExist = "Kiralamak isteyen müşteri bulunamadı!";
        public static string TheCarDoesNotExist = "Araç bulununamadı!";
        public static string ThereIsNoRentalWhichHasTheGivenId = "Bu değerlere sahip bir kiralama yok!";
        public static string RentalHasAlreadyDelivered = "Zaten kiralanmış!";
        public static string CustomersListed = "Müşteriler Listelendi";
        public static string Geted = "Alındı!";
        public static string Listed = "Listelendi!";
        public static string EmailIsAlreadyRegistered = "Bu e-mail daha önce kullanılmış!";
    }
}
