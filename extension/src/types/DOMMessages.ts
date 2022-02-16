import { Tags } from './Tags';

export type UpdateTagsRequest = {
  type: 'UPDATE_TAGS';
  value: Tags[];
};

export type UpdateTagsResponse = {
  success: boolean;
};

export type IdsMessage = {
  type: 'FETCH_IDS';
  ids: string[];
};
