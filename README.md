# HospitalDesktopApplication
Desktop application for hospital staff and patients.(ADO.NET)

Merhabalar.C# form uygulamasında(ADO.NET) geliştirmiş olduğum hastane uygulamasını size ayrıntılı bir şekilde anlatacağım.
 Masaüstü uygulamamız üç bölümden oluşuyor; hasta,doktor ve sekreter.

![Ekran Görüntüsü (1)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/b4248ab2-7484-4fa9-a012-e34566cce357)


Hasta giriş bölümünde hasta kayıt olma,kayıtlı hastanın kendi bilgilerini güncelleme ve hasta detay formuna geçiş için tc numarası ve  şifresi ile giriş yapıyor

![Ekran Görüntüsü (2)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/9ec87d68-aff2-4992-a484-58992e7ad5c5)


Tc numarası ya da şifrenin yanlış girilmesi durumunda hata veriliyor.

![Ekran Görüntüsü (7)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/164693a7-608c-4d6c-af12-13eb18610d69)


Hasta bölümünde uygulamayı ilk defa kullanıcak hasta için "Patient Registration" linkine tıklayıp kayıt olabilir.

![Ekran Görüntüsü (3)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/75ee35c5-fbab-43aa-8e57-3e7cde9a7d2d)


Bu bölümde hasta kayıt olurken her kaydı birbirinden ayıran eşsiz tc numarası kontrol edilir eğer daha önce o tc numarasına ait kayıt varsa hata mesajı verilir.
Sol üssteki buton ile formlar arası geçiş sağlanır.Clear butonu ile tüm kutucuklar temizlenebilir.

![Ekran Görüntüsü (4)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/5e64db24-9944-4bd0-b8a1-cc16fb7610e3)


Hasta bilgilerini güncelleme formunda önce hastanın tc numarasını girmesi istenir ve girdiği tc numarasına ait tüm bilgiler ilgili kutucuklara veri tabanından çekilir.

![Ekran Görüntüsü (5)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/9705ec2d-432a-4cbc-a27d-163bd35b8ef3)


Güncellenek kayıta ait tc numarası sistemde kayıtlı mı? Önce bu kontrol edilir.Olmayan bir kaydı güncellemeye çalışırsa hata verir.

![Ekran Görüntüsü (6)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/f485733e-03fe-4668-98f5-97a04745c001)


Hasta Detay formunda giriş yapan hasta geçmiş randevuları ve alınabilen randevuları bu bölümde görüntülüyor.

![Ekran Görüntüsü (8)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/943b54cc-fe49-4663-af61-962b4cbeec11)


Hasta Detay formunda randevu almak istediği branşı seçtiğinde o branşa ait doktorları görüntülüyor.Aktif randevu ve geçmiş randevu tablolarındaki herhangi  hücreye yani bir randevuya tıklandığı 
zaman o randevuya ait bilgiler tüm kutucuklara çekiliyor.


![Ekran Görüntüsü (9)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/533d68eb-1927-43ce-bf4d-dbfef4edb5a2)


Hasta seçtiği randevu alırken branşa ve doktora ait müsait bir randevu bulduktan sonra doktorun randevudan önce görebileceği şikayet metnini oluşturuyor.
Randevu alındıktan veya iptal ediltikten sonra hemen sonrasında tablolarımız yenileniyor.


![Ekran Görüntüsü (11)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/5f9ffbc7-cef6-4954-8211-9dd7ba704bc4)


Alınan randevunun bir daha alınamaması ve iptal edilen randevunun tekrar iptal edilememesi için hata mesajı veriyoruz.

![Ekran Görüntüsü (12)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/56876f63-d1f3-4497-9441-337a41861d67)


Sekreter formunda ise duyuru oluşturma,randevu bilgilerini ,doktor bilgilerini  ve branş bilgilerini düzenleme gibi işlemler yapılıyor.(CRUD işlemleri)

![Ekran Görüntüsü (13)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/3334996c-980d-4c42-9460-510b28be88d0)


ID numarası girilen ya da Randevular tablosundan seçilen randevunun tüm randevu bilgileri kutucuklara çekiliyor ayrıca ID kutucuğudaki numara silindiği zaman tüm kutucuklar temizleniyor.

![Ekran Görüntüsü (14)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/5f7772f5-1826-4e3e-96f4-83dd94cdb4fa)

Sekreter duyuru oluşturabiliyor ve doktorlar kendi panelinde bunu görüntüleyebilecek.
![Ekran Görüntüsü (15)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/eb3de925-231d-46dd-9b45-246dfb617c7b)

Olmayan bir kaydı silmeye ya da güncellemeye çalışmak ve var olan bir kaydı tekrar üst üste oluşturmaya çalışmak hata mesajı verir ve işlemi gerçekleştirmez.
![Ekran Görüntüsü (16)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/0a9b8bf2-18a5-4487-b1e2-15983744aade)
![Ekran Görüntüsü (17)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/ab2bf972-c38b-4e21-8d36-d04cfcf135c2)


Doctorları düzenleme formunda ise TC numarasını tc kutucuğuna girildiği anda veya tabloda tıklanılan hücrenin ait olduğu satırdaki doktor bilgileri tüm kutucuklara çekilir.
Her yerde kullandığımız özellik olan;olmayan bir kaydı silme veya güncellemek ya da kaydı tekrar üst üste kaydetmek hata verir ve işlem gerçekleşmez.
![Ekran Görüntüsü (18)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/08c9df8d-aba2-45fd-a83c-b4e548ec296c)


Branşları düzenleme bölümünde ise her formda uyguladığımız CRUD işemleri sonunda tablolarımızı(dataGridView) anında yeniliyoruz.

![Ekran Görüntüsü (19)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/3169e348-9250-4017-8dab-d87920dc2854)


Doktor formunda ise randevuya tıklayarak; randevuları,o randevuyu hangi hastanın aldığını,hastanın randevuyu alırken oluşturmuş olduğu şikayeti ve sekreterin oluşturduğu duyuruları görebiliyor.
![Ekran Görüntüsü (20)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/c5c2ff0e-14dd-42c1-a41a-9f5409255297)
![Ekran Görüntüsü (21)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/29532a33-57b9-4eca-9ce7-9c02d59ec402)

CRUD işlemlerinden hemen sonra butona basıldıktan sonra  formlardaki tüm dataGridViewileri yenilemek için bir sınıf oluşturdum.Bu sınıfta constructor oluşturup overloading ettim.Nesne oluşturuldu anda parametre olarak gönderilen tablo ismi ve datagridview isimlerini sınıfın kendi içindeki propertylerine atıyor.
![Ekran Görüntüsü (22)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/4063781a-3d4a-4610-9bb9-518561e83af0)


SlqConn sınıfımda ise bağlatımı açıp bağlantısı adresini döndürüyorum.

![Ekran Görüntüsü (23)](https://github.com/mhmdsrt/HospitalDesktopApplication/assets/164398109/eaef0cfa-1c6a-44c4-956a-6075b9768125)
