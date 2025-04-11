ALTER TABLE "check_response" ADD COLUMN "checksum" TEXT NOT NULL DEFAULT '';

ALTER TABLE "check_response" ADD CONSTRAINT check_response_unique UNIQUE ("checksum");
