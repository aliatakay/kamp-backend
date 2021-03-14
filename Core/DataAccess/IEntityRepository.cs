/* Kodların altında açıklamalar var. */
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
/*
        GetAll metodunu tüm datayı getirmek için kullanıyoruz fakat
        bu metoda filtreleme özelliği de kazandırmalıyız.
        Bu sayede metoda, filtrelenmiş sonuca göre dataları getirmesini söyleyebiliriz.

        Benzer şekilde, istediğimiz product datasını getirmesi için bir de "T Get()" metodu yazdık.
        Bu metot da LINQ sayesinde istediğimiz seçili product'ı bize verecek.

        Expression yapısını kullanarak metoda, filtreleme özelliği kazandırabiliriz.
        filter = null demek, istersen filtre vermeyebilirsin demektir.
        yani hiç filtre vermesen de metot çalışır ve haliyle tüm datayı getirir.

        filter demek, bir filtre sorgulaması vermek zorundasın demektir.
        yani metot parametresiz haliyle çalışamaz demektir.

        <Func<T, bool>> bu yapı Delegate yapısıdır. Buna konuya sonra geleceğiz.


        Generic Constraint (Generic Kısıt)
        Biz bu interface'i sadece "entity sınıfları" kullanabilsin diye yazdık.
        İçerisinde ekleme-güncelleme-silme işlemleri barındıran bir interface, yalnızca database sınıfları içindir çünkü.
        Bu sebepten T yerine yazılabilecek tipleri sınırlıyoruz.
        
        where T : class (yani T ne olabilir = class)
        Buradaki class = referans tip olabilir anlamındadır.
        yani T yalnızca bir referans tip olabilir demektir. (int, double vs olamaz.)

        ama bu yazım da belli açıklar oluşturuyor. where T : class
        where T : class bu yazım sebebiyle alakasız class'lar da bu interfacei kullanabilir.
        
        where T : class, IEntity == böyle yazarak şunu demiş oluruz:
            T hem bir referans tip olmalı hem de bir IEntity olmalı.
            Bütün db sınıflarımızı IEntity tanımlamıştık zaten.

        hala tam olarak doğru değil.
        çünkü IEntity interface'inin kendisinin bu generic yapıyı kullanmasını istemiyoruz.
        sadece IEntity'yi referans tutucu olarak kullanan somut sınıfların kullanmasını istiyoruz.
        
        where T : class, IEntity, new() == işte sonune new() eklersek, sadece newlenebilen tipler bunu kullansın demiş oluruz.
        yani IEntity'nin kendisi kullanamaz.
 */