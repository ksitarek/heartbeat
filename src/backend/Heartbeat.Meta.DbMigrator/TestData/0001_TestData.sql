INSERT INTO "app" ("id", "label") VALUES
    ('c1a1f750-dc71-4b4d-914d-afe308f640e5', 'Test App Alpha')
    ON CONFLICT ("id") DO NOTHING;

INSERT INTO "verification_status" (
    "id", "app_id", "created_at", "verification_token",
    "verification_strategy", "was_verification_successful"
) VALUES
    ('a2e4c6a0-780f-4e85-8f07-091f78f4d3ba', 'c1a1f750-dc71-4b4d-914d-afe308f640e5', '2025-04-03T08:00:00Z', '3B88EF30-A2A9-4768-93A7-75926F55BF3B', 'DnsRecord', TRUE)
    ON CONFLICT ("id") DO NOTHING;

INSERT INTO "check" (
    "id", "app_id", "label", "interval", "timeout",
    "retries", "url", "port", "expected_response", "collect_response"
) VALUES
    ('e1e3053e-3f71-4145-a230-48bb7bbfca37', 'c1a1f750-dc71-4b4d-914d-afe308f640e5', 'Homepage Check', '00:05:00', '00:00:30', 3, 'https://krystiansitarek.pl', 443, '200 OK', TRUE)
    ON CONFLICT ("id") DO NOTHING;

INSERT INTO "check_response" (
    "id", "response_collected", "response", "checksum"
) VALUES
    ('f1f82bfb-90a0-4b32-9989-218a21c5cc65', TRUE, 'HTTP/1.1 200 OK', '92413e9787e7d079d0aee62a9ec27ca7eb8e5e410a75a209a377a0c581743151')
    ON CONFLICT ("id") DO NOTHING;

INSERT INTO "check_status_log" (
    "id", "check_id", "status", "created_at", "check_response_id"
) VALUES
      ('5ac2b380-04bd-4e89-91cd-b8cf1b7091a1', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Up',      '2025-04-03T08:00:00Z', 'f1f82bfb-90a0-4b32-9989-218a21c5cc65'),
      ('bb19d1be-5474-4bfa-a697-1ce633c531fa', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Down',    '2025-04-04T08:00:00Z', NULL),
      ('f35f6878-5c6d-4d1b-8b96-914bdf5f0d49', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Up',      '2025-04-05T08:00:00Z', 'f1f82bfb-90a0-4b32-9989-218a21c5cc65'),
      ('11c5478a-8b89-4a59-b1d1-e39c79a5cbfd', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Down',    '2025-04-06T08:00:00Z', NULL),
      ('faefc474-f2bc-4064-b7a5-c2b9973b2e67', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Up',      '2025-04-07T08:00:00Z', 'f1f82bfb-90a0-4b32-9989-218a21c5cc65'),
      ('8b99d31e-91ee-4665-8ccf-7a573016d2de', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Down',    '2025-04-08T08:00:00Z', NULL),
      ('dd09c20b-e558-4899-b870-f19beea2746d', 'e1e3053e-3f71-4145-a230-48bb7bbfca37', 'Up',      '2025-04-09T08:00:00Z', 'f1f82bfb-90a0-4b32-9989-218a21c5cc65')
    ON CONFLICT ("id") DO NOTHING;