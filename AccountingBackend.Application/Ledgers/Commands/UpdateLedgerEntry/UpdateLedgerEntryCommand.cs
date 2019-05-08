/*
 * @CreateTime: May 8, 2019 2:11 PM
 * @Author:  Mikael Araya
 * @Contact: MikaelAraya12@gmail.com
 * @Last Modified By:  Mikael Araya
 * @Last Modified Time: May 8, 2019 2:32 PM
 * @Description: Modify Here, Please 
 */
using System;
using System.Collections.Generic;
using AccountingBackend.Application.Ledgers.Models;
using MediatR;

namespace AccountingBackend.Application.Ledgers.Commands.UpdateLedgerEntry {
    public class UpdateLedgerEntryCommand : IRequest {

        public UpdateLedgerEntryCommand () {
            Entries = new List<UpdatedLedgerEntryModel> ();
            DeletedIds = new List<int> ();
        }

        public int Id { get; set; }
        public string VoucherId { get; set; }
        public string Description { get; set; }

        public DateTime Date { get; set; }
        public string Reference { get; set; }
        public sbyte? Posted { get; set; }

        public IEnumerable<UpdatedLedgerEntryModel> Entries;
        public List<int> DeletedIds;

    }
}