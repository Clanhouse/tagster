import {IdsMessage, UpdateTagsRequest, UpdateTagsResponse} from '../types';
import ReactDOM from "react-dom";
import React from "react";
import {Autocomplete, TextField} from "@mui/material";

function updateComponents(msg: UpdateTagsRequest) {

}

const updateTagsListener = (
    msg: UpdateTagsRequest,
    sender: chrome.runtime.MessageSender,
    sendResponse: (response: UpdateTagsResponse) => void) => {

  console.log('[content.js]. Message received', msg);

  updateComponents(msg)

  sendResponse({success: true});
}


function onDomUpdate() {
  // TODO fetch real necessary IDs
  const ids = Array.from(document.getElementsByTagName<"h1">("h1"))
  .map(h1 => h1.innerText);

  const message: IdsMessage = {
    type: 'FETCH_IDS',
    ids: ids
  };

  console.log("[content] sending ids: " + ids)

  chrome.runtime.sendMessage(message, (response: UpdateTagsRequest) => {
    if (response.value) {
      console.log("[content] got tags back! Listing:");
      console.log(response.value);
      response.value.forEach(tags => console.log("id: " + tags.id + " tags: " + tags.tags));
      updateComponents(response);
    } else {
      console.log("[content] got empty tags")
    }
  });
}

chrome.runtime.onMessage.addListener(updateTagsListener);
const observer = new MutationObserver(onDomUpdate);
observer.observe(document, {attributes: true, childList: true, subtree: true});

const tagsPlaceholder = [
  {id: "asd", name: "Tag 1"},
  {id: "asd2", name: "Tag 2"},
  {id: "asd3", name: "A tag 1"},
  {id: "asd4", name: "Whatever 1"},
  {id: "asd5", name: "Bs 1"},
  {id: "asd6", name: "Kekezaur 1"},
  {id: "asd7", name: "Taggeroni 1"},
]

function setupReact() {
  const tagsterContentRoot = document.createElement("div");
  tagsterContentRoot.id = 'tagster-content-root';
  document.getElementsByTagName("body")[0].appendChild(tagsterContentRoot);

  ReactDOM.render(
      <React.StrictMode>
        <Autocomplete
            multiple
            limitTags={4}
            id="multiple-limit-tags"
            options={tagsPlaceholder}
            getOptionLabel={(option) => option.name}
            defaultValue={[tagsPlaceholder[0], tagsPlaceholder[1]]}
            renderInput={(params) => (
                <TextField {...params} label="Tags" placeholder="Add tag..."/>
            )}
            sx={{width: '500px'}}
        />
      </React.StrictMode>,
      document.getElementById('tagster-content-root')
  );
}

setupReact();