﻿namespace CleanArc_Kevin.Core.Abstractions.Events
{
    public interface IOutBoxEventItemRepository
    {
        public List<OutBoxEventItem> GetOutBoxEventItemsForPublish(int maxCount = 100);
        void MarkAsRead(List<OutBoxEventItem> outBoxEventItems);
    }
}