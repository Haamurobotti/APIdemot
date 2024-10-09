namespace QuestHarjoitus
{
    public class QuestItemDTO
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public int Reward { set; get; }

        public QuestItemDTO() {}

        public QuestItemDTO(Quest questItem) =>(Id, Name, Description, Reward) = (questItem.Id, questItem.Name, questItem.Description, questItem.Reward);
    }
}
