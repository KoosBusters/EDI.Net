using indice.Edi.Serialization;
using System.Collections.Generic;

namespace indice.Edi.Tests.Models.EdiFact01
{
    public class Interchange_RST
    {
        public Message_RST Message { get; set; }
    }

    [EdiMessage]
    public class Message_RST
    {
        public List<AAA_FIRST_SECTION> AAA_FIRST { get; set; }

        public UNS_Start_Section UNS { get; set; }

        public List<AAA_SECOND_SECTION> AAA_SECOND { get; set; }
    }

    //[EdiCondition("D", CheckFor = EdiConditionCheckType.Equal, Path = "UNS/0/0")]
    [EdiSegment, EdiPath("AAA")]
    //[EdiSegmentGroup("AAA", SequenceEnd = "UNS")]
    public class AAA_FIRST_SECTION
    {
        [EdiValue("9(3)", Path = "AAA/0/0")]
        public int AAAGroupSegmentOccurence { get; set; }
    }

    //[EdiCondition("D", CheckFor = EdiConditionCheckType.NotEqual, Path = "UNS/0/0")]
    [EdiSegmentGroup("AAA")]
    public class AAA_SECOND_SECTION
    {
        [EdiValue("9(3)", Path = "AAA/0/0")]
        public int AAAGroupSegmentOccurence { get; set; }

        public BBB BBB { get; set; }

    }

    [EdiSegment, EdiPath("BBB")]
    public class BBB
    {
        [EdiValue("X(6)", Path = "BBB/0/0")]
        public string BBBText1 { get; set; }

        [EdiValue("X(6)", Path = "BBB/0/1")]
        public string BBBText2 { get; set; }

        [EdiValue("X(6)", Path = "BBB/0/2")]
        public string BBBText3 { get; set; }

        [EdiValue("X(6)", Path = "BBB/0/3")]
        public string BBBText4 { get; set; }

        [EdiValue("9(3)", Path = "BBB/1/0")]
        public int BBBGroupSegmentOccurence { get; set; }
    }

    /// <summary>
    /// UNS - Section Control
    /// </summary>
    [EdiCondition("D", Path = "UNS/0")]
    [EdiSegment, EdiPath("UNS")]
    public class UNS_Start_Section
    {
        /// Start of the section
        /// *D  Header/detail section separation = START SECTION
        [EdiValue("X(1)", Path = "UNS/0", Mandatory = true)]
        public char? SectionIdentification { get; set; }
    }
}
