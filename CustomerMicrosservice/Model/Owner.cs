using Google.Cloud.Firestore;
using OwnerMicrosservice.Interfaces;

namespace OwnerMicrosservice.Model
{
    [FirestoreData]
    public class Owner : IBaseFirestoreData
    {
        public string Id { get; set; }
        [FirestoreProperty]
        public string Name { get; set; }
        [FirestoreProperty]
        public string Email { get; set; }
        [FirestoreProperty]
        public string Cpf { get; set; }
    }
}
