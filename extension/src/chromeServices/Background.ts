import {IdsMessage, UpdateTagsRequest} from "../types";
import {Tags} from "../types/Tags";
import MessageSender = chrome.runtime.MessageSender;

function fetchDataListener(message: IdsMessage, sender: MessageSender, sendResponse: (response: UpdateTagsRequest) => void) {
  console.log("background.ts got message" + message)
  //TODO fetch tags here for real
  const result: Tags[] = [];
  for (let id of message.ids) {
    result.push({id, tags: ["tag1", "tag 2", "tag 3"]});
  }
  sendResponse({type: 'UPDATE_TAGS', value: result})
}

chrome.runtime.onMessage.addListener(fetchDataListener);

export {}