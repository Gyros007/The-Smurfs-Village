using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using VIDE_Data;
using UnityEngine.UI;

public class QuestChartDemo : MonoBehaviour
{
    public static VIDE_Assign assigned;

    public GameObject questChartContainer;
    public GameObject ovGameObject;
    public GameObject peGameObject;

    //Tasks
    static int cylinderGuyTotal = 9;
    static List<string> interactedWith = new List<string>();
    static List<int> cylinderGuyInteractions = new List<int>();

    public Variables var;


    void Awake()
    {
        //Will load saved progress in PlayerPrefs
        LoadProgress();
    }

    void OnEnable()
    {
        assigned = GetComponent<VIDE_Assign>();
    }

    void Update()
    {
        //This is checking if the QuestChart UI Manager is reset
        if (gameObject != null)
            if (questChartContainer.activeSelf)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    PlayerPrefs.DeleteAll();
                    if (System.IO.Directory.Exists(Application.dataPath + "/VIDE/saves"))
                    {
                        System.IO.Directory.Delete(Application.dataPath + "/VIDE/saves", true);
                        #if UNITY_EDITOR
                        UnityEditor.AssetDatabase.Refresh();
                        #endif
                    }

                    #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                    #endif
                }
            }
    }

    // Will Use the SetVisible method to switch the visibility of a comment
    // When a comment is not visible, its content will not be included in the nodeData arrays
    // The method will also add info to an ExtraVariables key to mark the completion of a quest
    public static void SetQuest(int quest, bool visible)
    {
        VD.SetVisible(assigned.assignedDialogue, 0, quest, visible);
        Dictionary<string, object> newEV = VD.GetExtraVariables(assigned.assignedDialogue, 1);
        newEV["complete"] += "[" + quest.ToString() + "]";
        VD.SetExtraVariables(assigned.assignedDialogue, 1, newEV);
    }

    //Will start and end the assigned dialogue
    public void Interact()
    {
        if (!questChartContainer.activeSelf)
        {
            questChartContainer.SetActive(true);
            VD.NodeData nd = VD.BeginDialogue(assigned);
            LoadChart(nd);
        }
        else
        {
            for (int i = 0; i < peGameObject.transform.parent.childCount; i++)
                if (i != 0) Destroy(peGameObject.transform.parent.GetChild(i).gameObject);

            for (int i = 0; i < ovGameObject.transform.parent.childCount; i++)
                if (i != 0) Destroy(ovGameObject.transform.parent.GetChild(i).gameObject);

            questChartContainer.SetActive(false);
            VD.EndDialogue();
        }
    }

    // Uses both NodeData and local variables to populate the Quest UI
    public void LoadChart(VD.NodeData data)
    {

        if(var.metXefteris && !var.flag1)
        {
            data.comments[var.questPostitionXefteris] = "Collect 3 pieces of wood for Handy Smurf";
            VD.SetComment(VD.assigned.assignedDialogue, 0, var.questPostitionXefteris, "Collect 3 pieces of wood for Handy Smurf");
            VD.SetComment(VD.assigned.assignedDialogue, 1, var.questPostitionXefteris, "Collect 3 pieces of wood for Handy Smurf");
            var.flag1 = true;
        }
        
        if(var.metStrοumfita && !var.flagStrοumfita)
        {
            data.comments[var.questPostitionStoumfita] = "Collect a Vase and a Flower";
            VD.SetComment(VD.assigned.assignedDialogue, 0, var.questPostitionStoumfita, "Collect a Vase and a Flower");
            VD.SetComment(VD.assigned.assignedDialogue, 1, var.questPostitionStoumfita, "Collect a Vase and a Flower");
            var.flagStrοumfita = true;
        }

        if (var.metPainter && !var.flagPainter)
        {
            data.comments[var.questPostitionPainter] = "Find Painter's paintbrush";
            VD.SetComment(VD.assigned.assignedDialogue, 0, var.questPostitionPainter, "Find Painter's paintbrush");
            VD.SetComment(VD.assigned.assignedDialogue, 1, var.questPostitionPainter, "Find Painter's paintbrush");
            var.flagPainter = true;
        }
        
        if ((var.metGkriniaris || var.metPapastroumf) && !var.flagGkriniaris)
        {
            data.comments[var.questPostitionGkriniaris] = "Help Grouchy Smurf escape";
            VD.SetComment(VD.assigned.assignedDialogue, 0, var.questPostitionGkriniaris, "Help Grouchy Smurf escape");
            VD.SetComment(VD.assigned.assignedDialogue, 1, var.questPostitionGkriniaris, "Help Grouchy Smurf escape");
            var.flagGkriniaris = true;
        }

        if (var.metLixoudis && !var.flagLixoudis)
        {
            data.comments[var.questPostitionLixoudis] = "Collect 3 apples for Chef Smurf";
            VD.SetComment(VD.assigned.assignedDialogue, 0, var.questPostitionLixoudis, "Collect 3 apples for Chef Smurf");
            VD.SetComment(VD.assigned.assignedDialogue, 1, var.questPostitionLixoudis, "Collect 3 apples for Chef Smurf");
            var.flagLixoudis = true;
        }

        if (var.numXila == 3 && var.returnedToXefteri && !var.flag2)
        {
            SetQuest(var.questPostitionXefteris, true);
            var.flag2 = true;
        }
        
        if(var.foundVase && var.foundFlower && !var.flagStrοumfita2 && var.returnedToStroumfita)
        {
            SetQuest(var.questPostitionStoumfita, true);
            var.flagStrοumfita2 = true;
        }
        

        if (var.foundPaintBrush && !var.flagPainter2 && var.returnedToPainter)
        {
            SetQuest(var.questPostitionPainter, true);
            var.flagPainter2 = true;
        }
        
        if(var.foundSoap && !var.flagGkriniaris2 && var.returnedToGkriniaris)
        {
            SetQuest(var.questPostitionGkriniaris, true);
            var.flagGkriniaris2 = true;
        }

        if (var.numApples == 3 && !var.flagLixoudis2 && var.returnedToLixoudis)
        {
            SetQuest(var.questPostitionLixoudis, true);
            var.flagLixoudis2 = true;
        }

        //if (var.openPresent && !var.flagXaxanoulis2 && var.returnedToXaxanoulis)
        //{
        //SetQuest(var.questPostitionPainter, true);
        // var.flagXaxanoulis2 = true;
        //}

        //Overview quests
        VD.NodeData overviewData = VD.GetNodeData(assigned.assignedDialogue, 1, true);
        for (int i = 0; i < data.comments.Length; i++)
        {
            string completeKey = (string)overviewData.extraVars["complete"];

            GameObject ov = (GameObject)Instantiate(ovGameObject);
            if (completeKey.Contains("[" + i.ToString() + "]"))
            {
                ov.GetComponent<Text>().text = overviewData.comments[i] + " [✓]";
                ov.GetComponent<Text>().color = new Color32(191, 192, 177, 255);
            }
            else
            {
                ov.GetComponent<Text>().text = overviewData.comments[i];
            }
            ov.transform.SetParent(ovGameObject.transform.parent, true);
            ov.GetComponent<RectTransform>().sizeDelta = new Vector2(900, 67);
            ov.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -15 - (48 * i));
            if(data.comments[i].Contains("Collect 3 pieces of wood for Handy Smurf"))
                if(var.numXila < 3)
                    ov.GetComponent<Text>().text += " (" + var.numXila + "/" + "3)";
                else if (!var.returnedToXefteri)
                    ov.GetComponent<Text>().text += " (Return to Handy Smurf)";

            if (data.comments[i].Contains("Collect 3 apples for Chef Smurf"))
                if (var.numApples < 3)
                    ov.GetComponent<Text>().text += " (" + var.numApples + "/" + "3)";
                else if (!var.returnedToLixoudis)
                    ov.GetComponent<Text>().text += " (Return to Chef Smurf)";

            if (data.comments[i].Contains("Collect a Vase and a Flower"))
                if(!var.foundVase && !var.foundFlower)
                    ov.GetComponent<Text>().text += " (You haven't found anything yet)";
                else if(!var.foundVase && var.foundFlower)
                    ov.GetComponent<Text>().text += " (Only the vase is left to find)";
                else if(var.foundVase && !var.foundFlower)
                    ov.GetComponent<Text>().text += " (Only the flower is left to find)";
                else if (!var.returnedToStroumfita && var.foundVase && var.foundFlower)
                    ov.GetComponent<Text>().text += " (Return to Smurfette)";

            if (data.comments[i].Contains("Find Painter's paintbrush"))
                if (!var.foundPaintBrush)
                    ov.GetComponent<Text>().text += " (You haven't found the paintbrush)";
                else if (!var.returnedToPainter && var.foundPaintBrush)
                    ov.GetComponent<Text>().text += " (Return to Painter Smurf)";
            
             if (data.comments[i].Contains("Help Grouchy Smurf escape"))
                if (!var.foundSoap && var.metGkriniaris)
                    ov.GetComponent<Text>().text += " (Find a soap)";
                else if (!var.returnedToGkriniaris && var.foundSoap)
                    ov.GetComponent<Text>().text += " (Return to Grouchy Smurf)";           

            ov.SetActive(true);
        }
    }

    //Set CylinderGuy quest
    public static void CylinderGuyAddInteraction(int index)
    {
        if (!cylinderGuyInteractions.Contains(index))
            cylinderGuyInteractions.Add(index);
    }


    //Check some of the Quests completion
    public static void CheckTaskCompletion(VD.NodeData data)
    {
        if (VD.assigned == null) return;

        if (!interactedWith.Contains(VD.assigned.gameObject.name))
            interactedWith.Add(VD.assigned.gameObject.name);

        //Check
        // 0 Talk to Everyone
        // 1 Listen to CylinderGuy
        // 2 Get all items from Crazy Cap
        // 3 Threaten Charlie

        if (cylinderGuyInteractions.Count == cylinderGuyTotal) SetQuest(1, false);
    }

    //Set Charlie quest
    public void SetCharlieQuestComplete()
    {
        SetQuest(3, false);
    }

    public static void SaveProgress()
    {
        //var player = GameObject.Find("Player").GetComponent<VIDEDemoPlayer>();

        //List<string> items = player.demo_ItemInventory;
        //PlayerPrefs.SetInt("interactedWith", interactedWith.Count);
        //PlayerPrefs.SetInt("cylinderGuyInteractions", cylinderGuyInteractions.Count);
        //PlayerPrefs.SetInt("example_ItemInventory", items.Count);

        //for (int i = 0; i < interactedWith.Count; i++)
        //{
        //    PlayerPrefs.SetString("interWith" + i.ToString(), interactedWith[i]);
        //}

        //for (int i = 0; i < cylinderGuyInteractions.Count; i++)
        //{
        //    PlayerPrefs.SetInt("cylGuyInt" + i.ToString(), cylinderGuyInteractions[i]);
        //}

        //for (int i = 0; i < items.Count; i++)
        //{
        //    PlayerPrefs.SetString("item" + i.ToString(), items[i]);
        //}
    }

    public static void LoadProgress()
    {
        //var player = GameObject.Find("Player").GetComponent<VIDEDemoPlayer>();

        //if (!PlayerPrefs.HasKey("interactedWith")) return;

        //List<string> items = new List<string>(); ;

        //interactedWith = new List<string>();
        //cylinderGuyInteractions = new List<int>();

        //for (int i = 0; i < PlayerPrefs.GetInt("interactedWith"); i++)
        //{
        //    interactedWith.Add(PlayerPrefs.GetString("interWith" + i.ToString()));
        //}

        //for (int i = 0; i < PlayerPrefs.GetInt("cylinderGuyInteractions"); i++)
        //{
        //    cylinderGuyInteractions.Add(PlayerPrefs.GetInt("cylGuyInt" + i.ToString()));
        //}

        //for (int i = 0; i < PlayerPrefs.GetInt("example_ItemInventory"); i++)
        //{
        //    items.Add(PlayerPrefs.GetString("item" + i.ToString()));
        //}

        //player.demo_ItemInventory = items;
    }
}
