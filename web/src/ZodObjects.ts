import { z } from "zod";

export const AuthenticationMessage = z.object({
  authenticated: z.boolean(),
});

export const ItemMessage = z.object({
  uid: z.string().min(1).max(10),
  title: z.string().min(1),
  description: z.string(),
  serialNumber: z.string(),
  dateCreated: z.number(),
});