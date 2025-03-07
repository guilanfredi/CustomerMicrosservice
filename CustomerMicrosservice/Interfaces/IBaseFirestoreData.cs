﻿namespace OwnerMicrosservice.Interfaces
{
    /// <summary>
    /// Represents the base data that will exists on all records.
    /// </summary>
    public interface IBaseFirestoreData
    {
        /// <summary>
        /// Gets and set the Id.
        /// </summary>
        public string Id { get; set; }
    }
}
