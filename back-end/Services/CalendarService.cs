using System.Collections.Generic;
using webapi.Helpers;
using System.Linq;
using webapi.Models;
using System;
using webapi.Models.ViewModels;

namespace webapi.Services
{
    public interface ICalendarService
    {
        List<Reservation> GetReservationsByFieldId(int fieldId);
        void CreateReservation(Reservation reservation);
        List<ReservationVM> GetReservationById(int id);
        List<Reservation> SearchReservations(string title);

    }
    public class CalendarService : ICalendarService
    {

        private readonly DBContext _dbContext;

        public CalendarService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Reservation> GetReservationsByFieldId(int fieldId)
        {

            var reservations = (from r in _dbContext.Reservations
                                where r.FieldId == fieldId
                                select new Reservation
                                {
                                    Id = r.Id,
                                    Title = r.Title,
                                    Start = r.Start,
                                    End = r.End,
                                    FieldId = r.FieldId,
                                    Total = r.Total,
                                    PrimaryColor = r.PrimaryColor,
                                    SecondaryColor = r.SecondaryColor,
                                    CustomerId = r.CustomerId
                                }).ToList();


            return reservations;
        }

        public void CreateReservation(Reservation reservation)
        {
            Reservation reservationDTO = new Reservation();
            reservationDTO.Id = reservation.Id;
            reservationDTO.Start = reservation.Start;
            reservationDTO.End = reservation.End;
            reservationDTO.Title = reservation.Title;
            reservationDTO.FieldId = reservation.FieldId;
            reservationDTO.Total = reservation.Total;
            reservationDTO.PrimaryColor = reservation.PrimaryColor;
            reservationDTO.SecondaryColor = reservation.SecondaryColor;
            reservationDTO.CustomerId = reservation.CustomerId;

            _dbContext.Reservations.Add(reservationDTO);
            _dbContext.SaveChanges();

            // Get newly created reservationId
            var reservationId = reservationDTO.Id;

            DateTime paymentDate = DateTime.Now;

            Payment paymentDTO = new Payment();
            paymentDTO.Id = (int)reservationId;
            paymentDTO.TotalAmount = reservation.Total;
            paymentDTO.PaymentDate = paymentDate;

            _dbContext.Payments.Add(paymentDTO);
            _dbContext.SaveChanges();

            // Get newly created paymentId
            var paymentId = paymentDTO.PaymentId;

            // Save receipt obj to DB
            Receipt receipt = new Receipt();
            receipt.PaymentId = (int)paymentId;
            receipt.Id = (int)reservationId;
            receipt.FieldId = reservation.FieldId;
            receipt.TotalPrice = reservation.Total;

            _dbContext.Receipts.Add(receipt);
            _dbContext.SaveChanges();
        }

        /*
         This method is intended to return a list of events by Angular Bootstrap Calendar 6+
         in order to display the event.
        */
        public List<ReservationVM> GetReservationById(int id)
        {
            var reservation = (from r in _dbContext.Reservations
                               join f in _dbContext.Fields on r.FieldId equals f.FieldId
                               join fd in _dbContext.FieldDetails on f.FieldId equals fd.FieldId
                               where r.Id == id
                               select new ReservationVM
                               {
                                    Id = (int)r.Id,
                                    Title = r.Title,
                                    Start = r.Start,
                                    End = r.End,
                                    Total = r.Total,
                                    Field = f.Title,
                                    Path = f.PathURL,
                                    ImageURL = f.ImageURL,
                                    Description = fd.Description,
                                    Address = fd.Address,
                                    StartProgram = fd.StartProgram,
                                    EndProgram = fd.EndProgram
                               }).ToList();
            return reservation;
        }

        public List<Reservation> SearchReservations(string title)
        {

            var reservations = (from r in _dbContext.Reservations
                                where r.Title.ToLower().Contains(title.ToLower())
                                select new Reservation
                                {
                                    Id = r.Id,
                                    Title = r.Title,
                                    Start = r.Start,
                                    End = r.End,
                                    FieldId = r.FieldId,
                                    Total = r.Total,
                                    PrimaryColor = r.PrimaryColor,
                                    SecondaryColor = r.SecondaryColor,
                                    CustomerId = r.CustomerId
                                }).ToList();

            return reservations;
        }

    }
}