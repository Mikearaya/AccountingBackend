/*
 * @CreateTime: May 8, 2019 8:34 AM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 9:27 AM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.CreateLedgerEntry {
    public class CreateLedgerEntryCommand : IRequest<int> {
        public CreateLedgerEntryCommand () {
            Entries = new List<NewLedgerEntryModel> ();
        }

        public string Description { get; set; }
        public string Date { get; set; }
        public string Reference { get; set; }
        public string VoucherId { get; set; }
        public sbyte Posted { get; set; }

        public IEnumerable<NewLedgerEntryModel> Entries { get; set; }
    }
}