﻿using RVAProject.AppServices.Helpers;
using RVAProject.Common;
using RVAProject.Common.DTOs.PublisherDTO;
using RVAProject.Common.Entities;
using RVAProject.Common.Repositories;
using RVAProject.Common.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using System.Threading.Tasks;

using Publisher = RVAProject.Common.Entities.Publisher;

namespace RVAProject.AppServices
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PublisherService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PublisherService.svc or PublisherService.svc.cs at the Solution Explorer and start debugging.
    public class PublisherService : IPublisherService
    {
        private IPublisherRepository _publisherRepository;
        public PublisherService()
        {
            _publisherRepository = new PublisherRepository(new LibraryDbContext());
        }
        public async Task AddPublisher(PublisherRequest publisherRequest)
        {
            var publisher = new Publisher
            {
                Id = Guid.NewGuid(),
                Name = publisherRequest.Name,
                Address = publisherRequest.Address,
                Email = publisherRequest.Email,
                Books = new List<Book>()
            };
            await _publisherRepository.AddPublisher(publisher);
            Logger.Info($" Publisher added: Email: {publisher.Email}, Name: {publisher.Name}, Addres : {publisher.Address}");
        }

        public async Task<IEnumerable<PublisherInfo>> GetAllPublishers()
        {
            var publishers = await _publisherRepository.GetAllPublishers();
            Logger.Info("Publishers get method are successfully executed");
            return publishers.AsPublisherInfoList();
        }

        public async Task<PublisherInfo> GetPublisherById(Guid id)
        {
            var existingPublisher = await _publisherRepository.GetPublisherById(id);

            if (existingPublisher == null)
            {
                Logger.Error($" Publisher with id: {id} does not exist");
                throw new CustomAppException("Publisher does not exist");
            }

            Logger.Info($" Publisher with id: {id} is deleted");
            return existingPublisher.AsPublisherInfo();
        }

        public async Task UpdatePublisher(UpdatePublisherRequest updatePublisherRequest)
        {
            var existingPublisher = await _publisherRepository.GetPublisherById(updatePublisherRequest.Id);

            if (existingPublisher == null)
            {
                Logger.Error("Publisher does not exist");
                throw new CustomAppException("Publisher does not exist");
            }

            existingPublisher.Name = updatePublisherRequest.Name;
            existingPublisher.Email = updatePublisherRequest.Email;
            existingPublisher.Address = updatePublisherRequest.Address;

            await _publisherRepository.SaveChangesPublisher();
            Logger.Info($" Publisher updated: Email: {existingPublisher.Email}, Name: {existingPublisher.Name}, Addres : {existingPublisher.Address}");
        }
        public async Task DeletePublisher(Guid id)
        {
            var existingPublisher = await _publisherRepository.GetPublisherById(id);

            if (existingPublisher == null)
            {
                Logger.Error($" Publisher with id: {id} does not exist");
                throw new CustomAppException("Publisher does not exist");
            }

            await _publisherRepository.DeletePublisher(existingPublisher);
            Logger.Info($" Publisher with id: {id} is deleted");
        }
    }
}
